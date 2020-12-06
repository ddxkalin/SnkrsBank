namespace SnkrsBank.Web.Areas.Admin.Models.SalePosts
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;

    public class SneakerVM : IMapFrom<Sneaker>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}