namespace SnkrsBank.Services.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SnkrsBank.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApplicationUserManager<TUser> : UserManager<User>
           where TUser : User
    {
        public ApplicationUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<IdentityResult> ActivateUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsActive = true;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeactivateUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsActive = false;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsDeleted = true;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> RestoreUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsDeleted = false;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> UnlockUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.LockoutEnd = DateTime.UtcNow;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> SetEmailConfirmationTokenResentOnAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            User user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.EmailConfirmationTokenResentOn = DateTime.UtcNow;

            return await this.UpdateAsync(user);
        }
    }
}
