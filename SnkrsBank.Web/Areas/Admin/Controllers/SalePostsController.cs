namespace SnkrsBank.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNetCore.Mvc;

    using SnkrsBank.Domain.Models;
    using SnkrsBank.Services.Contracts;
    using SnkrsBank.Web.Areas.Admin.Controllers.Base;
    using SnkrsBank.Web.Areas.Admin.Models;
    using SnkrsBank.Web.Areas.Admin.Models.SalePosts;

    using System.Linq;
    using System.Threading.Tasks;

    public class SalePostsController : EntityListController
    {
        private ICrudService<SalePost> salePostService;

        public SalePostsController(ICrudService<SalePost> salePostService)
        {
            this.salePostService = salePostService;
        }

        [HttpGet]
        [Route("admin/posts")]
        public IActionResult Index(PaginationVM pagination, string movieName)
        {
            if (this.HasAlert)
            {
                this.SetAlertModel();
            }

            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<SalePost, PostVM>().ReverseMap());

            var postsQuery = this.salePostService.GetAllWithDeleted();

            if (!string.IsNullOrWhiteSpace(movieName))
            {
                postsQuery = postsQuery.Where(u => u.Sneaker.Name.ToLower().Contains(movieName.ToLower()));
            }

            postsQuery = postsQuery.OrderBy(u => u.IsDeleted).ThenByDescending(u => u.CreatedOn);

            var paginatedPosts = this.PaginateList<PostVM>(pagination, postsQuery.ProjectTo<PostVM>(configuration)).ToList();

            int totalPages = this.GetTotalPages(pagination.PageSize, postsQuery.Count());

            return this.View(new PostListVM
            {
                Posts = paginatedPosts,
                NextPage = pagination.Page < totalPages ? pagination.Page + 1 : pagination.Page,
                PreviousPage = pagination.Page > 1 ? pagination.Page - 1 : pagination.Page,
                CurrentPage = pagination.Page,
                TotalPages = totalPages,
                ShowPagination = totalPages > 1,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/posts/delete")]
        public async Task<IActionResult> Delete(string postId)
        {
            if (string.IsNullOrWhiteSpace(postId))
            {
                return this.BadRequest($"invalid post id");
            }

            PaginationVM pagination = this.GetCurrentPagination();

            await this.salePostService.Delete(postId);

            this.AddAlert(true, "Successfully deleted post");

            return this.RedirectToAction("Index", new { pagination.Page, pagination.PageSize, sneakerName = this.Request.Query["sneakerName"] });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/posts/restore")]
        public async Task<IActionResult> Restore(string postId)
        {
            if (string.IsNullOrWhiteSpace(postId))
            {
                return this.BadRequest($"invalid post id");
            }

            PaginationVM pagination = this.GetCurrentPagination();

            await this.salePostService.Restore(postId);

            this.AddAlert(true, "Successfully restored post");

            return this.RedirectToAction("Index", new { pagination.Page, pagination.PageSize, sneakerName = this.Request.Query["sneakerName"] });
        }
    }
}