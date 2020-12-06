namespace SnkrsBank.Web.Areas.Admin.Models.User
{
    using SnkrsBank.Domain.Models;
    using SnkrsBank.Web.App_Start;
    using System;

    public class UserVM : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
