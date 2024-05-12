using IMS.Application.Extension.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace WebUI.Components.Layout.Identity
{
    public sealed class IdentityRevalidatingAuthStateProvider(ILoggerFactory loggerFactory,
        IServiceScopeFactory scopeFactory, IOptions<IdentityOptions> options)
        : RevalidatingServerAuthenticationStateProvider(loggerFactory)
    {
        protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(20);

        protected async override Task<bool> ValidateAuthenticationStateAsync(
            AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            await using var scope = scopeFactory.CreateAsyncScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            return await ValidateSecurityStampAsync(userManager, authenticationState.User);
        }

        private async Task<bool> ValidateSecurityStampAsync(UserManager<ApplicationUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);
            if (user is null) 
            { 
                return false;
            }
            else if(!userManager.SupportsUserSecurityStamp)
            {
                return true;
            }
            else
            {
                var pricipalStamp = claimsPrincipal.FindFirstValue(options.Value.ClaimsIdentity.SecurityStampClaimType);
                var userStamp= await userManager.GetSecurityStampAsync(user);
                return pricipalStamp== userStamp;
            }
        }
    }
}
