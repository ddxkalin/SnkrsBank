namespace SnkrsBank.Services.Identity
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SnkrsBank.Domain.Models;
    using System.Threading.Tasks;

    public class ApplicationSignInManager<TUser> : SignInManager<User>
       where TUser : User
    {
        public ApplicationSignInManager(
            ApplicationUserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger,
            IAuthenticationSchemeProvider schemeProvider)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider)
        {
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe, bool lockoutOnFailure)
        {
            var user = await this.UserManager.FindByEmailAsync(userName);

            if (user == null || !user.IsActive || user.IsDeleted)
            {
                return SignInResult.NotAllowed;
            }

            return await this.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: lockoutOnFailure);
        }
    }
}
