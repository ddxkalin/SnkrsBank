namespace SnkrsBank.Web.Areas.Admin.Models.SalePosts
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;

    using System;

    public class PostVM : IMapFrom<SalePost>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public SneakerVM Movie { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
