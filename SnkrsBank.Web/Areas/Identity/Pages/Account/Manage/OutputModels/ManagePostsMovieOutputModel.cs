namespace SnkrsBank.Web.Areas.Identity.Pages.Account.Manage.OutputModels
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;

    public class ManagePostsMovieOutputModel : IMapFrom<Sneaker>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}
