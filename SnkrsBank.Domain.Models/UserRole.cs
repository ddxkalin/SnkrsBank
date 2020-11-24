namespace SnkrsBank.Domain.Models
{
    using Microsoft.AspNetCore.Identity;
    using SnkrsBank.Domain.Common.Models;
    using System;

    public class UserRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public UserRole()
            : this(null)
        {
        }

        public UserRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
