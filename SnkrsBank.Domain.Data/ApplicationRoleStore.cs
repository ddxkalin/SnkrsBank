namespace SnkrsBank.Domain.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using SnkrsBank.Domain.Models;
    using System.Security.Claims;

    public class ApplicationRoleStore : RoleStore<
           UserRole,
           SnkrsBankDbContext,
           string,
           IdentityUserRole<string>,
           IdentityRoleClaim<string>>
    {
        public ApplicationRoleStore(SnkrsBankDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityRoleClaim<string> CreateRoleClaim(UserRole role, Claim claim) =>
            new IdentityRoleClaim<string>
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
    }
}