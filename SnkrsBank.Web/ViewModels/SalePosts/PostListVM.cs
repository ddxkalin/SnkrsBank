namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System.Collections.Generic;

    public class PostListVM /*: PaginatedWithMappingVM<SalePost>*/
    {
        public List<PostVM> Posts { get; set; }
    }
}