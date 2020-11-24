namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.ViewModels.Base;
    using System.Collections.Generic;

    public class PostListVM : PaginatedWithMappingVM<SalePost>
    {
        public List<PostVM> Posts { get; set; }
    }
}