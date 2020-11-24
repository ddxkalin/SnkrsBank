﻿namespace SnkrsBank.Domain.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using SnkrsBank.Domain.Models;
    using System.Security.Claims;

    public class ApplicationUserStore : UserStore<
        User,
        UserRole,
        SnkrsBankDbContext,
        string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityUserToken<string>,
        IdentityRoleClaim<string>>
    {
        public ApplicationUserStore(SnkrsBankDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityUserRole<string> CreateUserRole(User user, UserRole role)
        {
            return new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id };
        }

        protected override IdentityUserClaim<string> CreateUserClaim(User user, Claim claim)
        {
            var identityUserClaim = new IdentityUserClaim<string> { UserId = user.Id };
            identityUserClaim.InitializeFromClaim(claim);
            return identityUserClaim;
        }

        protected override IdentityUserLogin<string> CreateUserLogin(User user, UserLoginInfo login) =>
            new IdentityUserLogin<string>
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };

        protected override IdentityUserToken<string> CreateUserToken(
            User user,
            string loginProvider,
            string name,
            string value)
        {
            var token = new IdentityUserToken<string>
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
            return token;
        }
    }
}