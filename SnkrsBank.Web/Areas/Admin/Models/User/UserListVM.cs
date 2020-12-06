namespace SnkrsBank.Web.Areas.Admin.Models.User
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.Areas.Admin.Models.Base;

    using System.Collections.Generic;

    public class UserListVM : PaginatedWithMappingVM<User>
    {
        public List<UserVM> Users { get; set; }
    }
}