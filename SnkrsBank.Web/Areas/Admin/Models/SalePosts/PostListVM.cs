namespace SnkrsBank.Web.Areas.Admin.Models.SalePosts
{
    using SnkrsBank.Web.Areas.Admin.Models.Base;
    using System.Collections.Generic;

    public class PostListVM : PaginatedWithMappingVM<PostVM>
    {
        public List<PostVM> Posts { get; set; }
    }
}
