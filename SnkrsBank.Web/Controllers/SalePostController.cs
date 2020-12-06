namespace SnkrsBank.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    using SnkrsBank.Domain.Models;
    using SnkrsBank.Services.Contracts;
    using SnkrsBank.Services.Identity;
    using SnkrsBank.Services.Utils;
    using SnkrsBank.Web.Controllers.Base;
    using SnkrsBank.Web.ViewModels;
    using SnkrsBank.Web.ViewModels.SalePosts;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SalePostController : EntityListController
    {
        private IHostingEnvironment hostingEnvironment;
        private ApplicationUserManager<User> userManager;

        private readonly IMapper _mapper;

        private ICrudService<SalePost> salePostService;
        private ICrudService<Category> sneakerCategoryService;
        private ICrudService<Sneaker> sneakerService;

        public SalePostController(
            ICrudService<SalePost> salePostService,
            ICrudService<Category> sneakerCategoryService,
            ICrudService<Sneaker> sneakerService,
            IHostingEnvironment hostingEnvironment,
            ApplicationUserManager<User> userManager,
            IMapper _mapper)

        {
            this.salePostService = salePostService;
            this.sneakerService = sneakerService;
            this.sneakerCategoryService = sneakerCategoryService;
            this._mapper = _mapper;

            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        [Route("salePosts")]
        public IActionResult Index(PaginationVM pagination, PostFilterVM postFilter)
        {
            if (this.HasAlert)
            {
                this.SetAlertModel();
            }

            var configuration = new MapperConfiguration(cfg =>
               cfg.CreateMap<SalePost, PostVM>().ReverseMap());

            var postsQuery = this.FilterPosts(postFilter, this.salePostService.GetAll().ProjectTo<PostVM>(configuration));

            var paginatedPosts = this.PaginateList<PostVM>(pagination, postsQuery).ToList();

            foreach (var post in paginatedPosts)
            {
                post.Sneaker.PosterImageRelativeLink = FileManager.GetRelativeFilePath(post.Sneaker.PosterImageLink);
                post.Sneaker.OverallRating = post.Sneaker.Ratings.Any() ? post.Sneaker.Ratings.Average(s => s.Rating.Score) : 0;
            }

            int totalPages = this.GetTotalPages(pagination.PageSize, postsQuery.Count());

            PostListVM postListViewModel = new PostListVM
            {
                Posts = paginatedPosts,
                NextPage = pagination.Page < totalPages ? pagination.Page + 1 : pagination.Page,
                PreviousPage = pagination.Page > 1 ? pagination.Page - 1 : pagination.Page,
                CurrentPage = pagination.Page,
                TotalPages = totalPages,
                ShowPagination = totalPages > 1,
            };

            this.LoadListSneakersDropdowns(postFilter);

            return this.View(postListViewModel);
        }

        [HttpGet]
        [Route("posts/create")]
        public IActionResult Create()
        {
            this.LoadCreateSneakerDropdowns();

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/create")]
        public async Task<IActionResult> Create(CreatePostVM salePostModel)
        {
            if (this.HasAlert)
            {
                this.SetAlertModel();
            }

            if (!this.ModelState.IsValid)
            {
                this.AddAlert(false, "An error has occured!");

                //this.LoadListSneakersDropdowns();
                return this.View(salePostModel);
            }

            var post = _mapper.Map<SalePost>(salePostModel);

            post.UserId = this.userManager.GetUserId(this.User);

            post.Sneaker.Slug = SlugGenerator.GenerateSlug(post.Sneaker.Name);
            post.Sneaker.PosterImageLink = await FileManager.SaveFile(this.hostingEnvironment, salePostModel.Sneaker.PosterImage);

            var rating = _mapper.Map<Rating>(salePostModel.Sneaker.Rating);
            rating.RatedById = this.userManager.GetUserId(this.User);
            rating.RatedOn = DateTime.Now;

            post.Sneaker.SneakerRatings.Add(new SneakerRating { Rating = rating });

            foreach (var keyword in salePostModel.Sneaker.KeywordsString.Trim().Split(","))
            {
                post.Sneaker.Keywords.Add(new Keyword { Name = keyword.Trim() });
            }

            try
            {
                await this.salePostService.Create(post);
            }
            catch (DbUpdateException e)
            when (e.InnerException is SqlException sqlEx &&
                (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                this.AddAlert(false, "Cannot insert duplicate sneaker!");

                //TODO =>
                //this.LoadListSneakersDropdowns();
                return this.View(salePostModel);
            }

            this.AddAlert(true, "Successfully added post!");

            return this.RedirectToAction("Index", new PaginationVM { Page = 1, PageSize = 20 });
        }

        [Route("posts/post/{postId}")]
        public IActionResult Post(string postId)
        {
            if (this.HasAlert)
            {
                this.SetAlertModel();
            }

            var postModel = _mapper.Map<PostVM>(salePostService.GetAll().Where(p => p.Id == postId).FirstOrDefault());

            if (postModel == null)
            {
                return this.NotFound("Post not found!");
            }

            var userId = this.userManager.GetUserId(this.User);

            postModel.Sneaker.PosterImageRelativeLink = FileManager.GetRelativeFilePath(postModel.Sneaker.PosterImageLink);
            postModel.Sneaker.OverallRating = postModel.Sneaker.Ratings.Any() ? postModel.Sneaker.Ratings.Average(s => s.Rating.Score) : 0;
            postModel.Sneaker.IsInWishlist = postModel.Sneaker.UserWishlists.Any(w => w.User.Id == userId);

            var currentUserRating = postModel.Sneaker.Ratings.Where(r => r.Rating.RatedBy.Id == userId).LastOrDefault()?.Rating.Score;
            postModel.Sneaker.GivenUserRating = currentUserRating.HasValue ? currentUserRating.Value : 0;

            return this.View(postModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/post/{postId}/rate")]
        public async Task<IActionResult> RatePost(string postId, int rating)
        {
            var post = this.salePostService.GetAll().Where(p => p.Id == postId)
                .Include(p => p.Sneaker)
                .ThenInclude(m => m.SneakerRatings)
                .ThenInclude(r => r.Rating)
                .FirstOrDefault();

            if (post == null)
            {
                return this.NotFound("Post not found");
            }

            var userId = this.userManager.GetUserId(this.User);

            if (rating > 0 && rating <= 5)
            {
                var currentUserRating = post.Sneaker.SneakerRatings.Where(r => r.Rating.RatedById == userId).LastOrDefault();

                if (currentUserRating == null)
                {
                    post.Sneaker.SneakerRatings.Add(new SneakerRating
                    {
                        SneakerId = post.SneakerId,
                        Rating = new Rating
                        {
                            RatedById = userId,
                            Score = rating,
                            RatedOn = DateTime.Now
                        }
                    });
                }
                else
                {
                    currentUserRating.Rating.Score = rating;
                }

                await this.salePostService.Update(post);

                double overallRating = post.Sneaker.SneakerRatings.Any() ? post.Sneaker.SneakerRatings.Average(s => s.Rating.Score) : 0;

                return this.Json(new { overallRating });
            }

            return this.BadRequest("invalid rating");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/post/{postId}/add-to-wishlist")]
        public async Task<IActionResult> AddToWishlist(string postId)
        {
            var post = this.salePostService.GetAll().Where(p => p.Id == postId)
                .Include(p => p.Sneaker)
                .ThenInclude(m => m.UserWishlists)
                .FirstOrDefault();

            if (post == null)
            {
                return this.NotFound("Post not found!");
            }

            var userId = this.userManager.GetUserId(this.User);

            bool hasInWishlist = post.Sneaker.UserWishlists.Any(w => w.UserId == userId);

            if (!hasInWishlist)
            {
                post.Sneaker.UserWishlists.Add(new UserWishlist { UserId = userId });
                await this.salePostService.Update(post);
            }

            return this.Json(new AlertVM { Success = true, Message = "Added to wishlist!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/post/{postId}/remove-from-wishlist")]
        public async Task<IActionResult> RemoveFromWishlist(string postId)
        {
            var post = this.salePostService.GetAll().Where(p => p.Id == postId)
                .Include(p => p.Sneaker)
                .ThenInclude(m => m.UserWishlists)
                .FirstOrDefault();

            if (post == null)
            {
                return this.NotFound("Post not found");
            }

            var userId = this.userManager.GetUserId(this.User);

            var userWishlistEntry = post.Sneaker.UserWishlists.Where(w => w.UserId == userId).FirstOrDefault();

            if (userWishlistEntry != null)
            {
                post.Sneaker.UserWishlists.Remove(userWishlistEntry);
                await this.salePostService.Update(post);
            }

            return this.Json(new AlertVM { Success = true, Message = "Removed from wishlist" });
        }


        private void LoadCreateSneakerDropdowns()
        {
            this.ViewBag.SneakerCategories = this.sneakerCategoryService.GetAll().OrderBy(e => e.Name)
                .Select(e => new SelectListItem { Text = e.Name, Value = e.Id })
                .ToList();
        }

        private void LoadListSneakersDropdowns(PostFilterVM postFilter)
        {
            this.ViewBag.OrderBy = new List<SelectListItem>
            {
                new SelectListItem { Text = "Alphabetical", Value = "alphabetical", Selected = postFilter.OrderBy == "alphabetical" },
                new SelectListItem { Text = "Category", Value = "category", Selected = postFilter.OrderBy == "category" },
                new SelectListItem { Text = "Rating", Value = "rating", Selected = postFilter.OrderBy == "rating" },
            };

            this.ViewBag.Ratings = new List<SelectListItem>
            {
                new SelectListItem { Text = "0", Value = "0", Selected = postFilter.RatingAbove == 0 },
                new SelectListItem { Text = "1", Value = "1", Selected = postFilter.RatingAbove == 1 },
                new SelectListItem { Text = "2", Value = "2", Selected = postFilter.RatingAbove == 2 },
                new SelectListItem { Text = "3", Value = "3", Selected = postFilter.RatingAbove == 4 },
                new SelectListItem { Text = "4", Value = "4", Selected = postFilter.RatingAbove == 4 },
                new SelectListItem { Text = "5", Value = "5", Selected = postFilter.RatingAbove == 5 },
            };

            this.ViewBag.SneakerCategories = this.sneakerCategoryService.GetAll().OrderBy(e => e.Name)
                .Select(e => new SelectListItem { Text = e.Name, Value = e.Name.ToLower(), Selected = postFilter.SneakerCategory == e.Name.ToLower() })
                .ToList();
        }

        private IQueryable<PostVM> FilterPosts(PostFilterVM filter, IQueryable<PostVM> query)
        {
            if (string.IsNullOrWhiteSpace(filter.OrderBy))
            {
                query = query.OrderBy(q => q.Sneaker.Name);
            }
            else
            {
                switch (filter.OrderBy.Trim().ToLower())
                {
                    case "alphabetical":
                        {
                            query = query.OrderBy(q => q.Sneaker.Name);
                        }

                        break;
                    case "rating":
                        {
                            query = query.OrderBy(q => q.Sneaker.Ratings.Average(s => s.Rating.Score));
                        }

                        break;
                    case "category":
                        {
                            query = query.OrderBy(q => q.Sneaker.Categories.First().Category.Name);
                        }

                        break;
                }
            }

            query = query.Where(q => q.Sneaker.Ratings.Average(m => m.Rating.Score) >= filter.RatingAbove);

            if (!string.IsNullOrWhiteSpace(filter.SneakerName))
            {
                query = query.Where(q => q.Sneaker.Name.ToLower().Contains(filter.SneakerName.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SneakerCategory))
            {
                query = query.Where(q => q.Sneaker.Categories.First().Category.Name.ToLower() == filter.SneakerCategory);
            }

            if (!string.IsNullOrWhiteSpace(filter.Keyword))
            {
                query = query.Where(q => q.Sneaker.Keywords.Any(k => k.Name == filter.Keyword));
            }

            return query;
        }
    }
}
