namespace SnkrsBank.Web.Areas.Identity.Pages.Account.Manage.OutputModels
{
    using System;

    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;

    public class ManagePostsOutputModel : IMapFrom<SalePost>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ManagePostsMovieOutputModel Movie { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
