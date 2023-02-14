using GymRatApi.Dto;
using GymRatApi.ModuleData.Dto;
using GymRatFront.ClientService;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GymRatFront.Providers
{
    public class GymRatAuthenticationProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationService authenticationService;

        public GymRatAuthenticationProvider(IAuthenticationService authenticationService) 
        {
            this.authenticationService = authenticationService;

            this.authenticationService.LogdChanged += AuthenticationService_LogdChanged;
        }
      
        private void AuthenticationService_LogdChanged(object? sender, LoggedUserDto e)
        {
            List<Claim> claims = null;
            if (e != null)
            {
                claims = new List<Claim>() {
                  new Claim(ClaimTypes.Name, e.Name),
                  new Claim(ClaimTypes.Email, e.Email),
                  new Claim(ClaimTypes.Role, e.Role),
                  new Claim(ClaimTypes.Authentication, e.Jwt)
                };
            }

            var user = claims != null ? new ClaimsIdentity(claims, "authUser") : new ClaimsIdentity();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user))));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsIdentity();
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}
