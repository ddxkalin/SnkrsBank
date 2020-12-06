namespace SnkrsBank.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SnkrsBank.Domain.Models;
    using SnkrsBank.Services.Contracts;
    using SnkrsBank.Services.Identity;
    using SnkrsBank.Web.Areas.Admin.Controllers.Base;
    using SnkrsBank.Web.Areas.Admin.Models;
    using SnkrsBank.Web.Areas.Admin.Models.User;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : EntityListController
    {
        private ApplicationUserManager<User> userManager;
        private ICrudService<SalePost> salePostService;

        public UsersController(ApplicationUserManager<User> userManager, ICrudService<SalePost> salePostService)
        {
            this.userManager = userManager;
            this.salePostService = salePostService;
        }

        [HttpGet]
        [Route("admin/users")]
        public IActionResult Index(PaginationVM pagination, string usernameEmail)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserVM>().ReverseMap());

            string currentId = this.userManager.GetUserId(this.User);
            var usersQuery = this.userManager.Users.Where(u => u.Id != currentId);

            if(!string.IsNullOrWhiteSpace(usernameEmail))
            {
                usersQuery = usersQuery.Where(u => u.UserName.ToLower().Contains(usernameEmail.ToLower()) || u.Email.ToLower().Contains(usernameEmail.ToLower()));
            }

            usersQuery = usersQuery.OrderBy(u => u.IsDeleted).ThenByDescending(u => u.CreatedOn);

            var paginatedUsers = this.PaginateList<UserVM>(pagination, usersQuery.ProjectTo<UserVM>(configuration)).ToList();

            int totalPages = this.GetTotalPages(pagination.PageSize, usersQuery.Count());

            return this.View(new UserListVM
            {
                Users = paginatedUsers,
                NextPage = pagination.Page < totalPages ? pagination.Page + 1 : pagination.Page,
                PreviousPage = pagination.Page > 1 ? pagination.Page - 1 : pagination.Page,
                CurrentPage = pagination.Page,
                TotalPages = totalPages,
                ShowPagination = totalPages > 1,
            });
        }

        [HttpGet]
        [Route("admin/user/{userId}")]
        public IActionResult UserProfile(string userId)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserVM>().ReverseMap());

            if (string.IsNullOrWhiteSpace(userId))
            {
                return this.NotFound($"invalid user id");
            }

            var user = this.userManager.Users.Where(u => u.Id == userId).ProjectTo<UserVM>(configuration).FirstOrDefault();

            var mappeedUser = user;

            if (user == null)
            {
                return this.NotFound($"user not found");
            }

            if (this.HasAlert)
            {
                this.SetAlertModel();
            }

            return this.View(user);
        }

        [HttpPost]
        [Route("admin/user/{userId}/activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return this.NotFound($"invalid user id");
            }

            IdentityResult result = await this.userManager.ActivateUserAsync(userId);

            await this.salePostService.Restore(this.salePostService.GetAllWithDeleted().Where(p => p.UserId == userId));

            this.AddAlert(true, "User account successfully activated");

            return this.RedirectToAction("UserProfile", "Users", new { userId });
        }

        [HttpPost]
        [Route("admin/user/{userId}/deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return this.NotFound($"invalid user id");
            }

            IdentityResult result = await this.userManager.DeactivateUserAsync(userId);

            await this.salePostService.Delete(this.salePostService.GetAllWithDeleted().Where(p => p.UserId == userId));

            this.AddAlert(true, "User account successfully deactivated");

            return this.RedirectToAction("UserProfile", "Users", new { userId });
        }
    }
}
