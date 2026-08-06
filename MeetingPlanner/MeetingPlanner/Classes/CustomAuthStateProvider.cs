using MeetingPlanner.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MeetingPlanner.Classes
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private InMemoryAuthService authService;

        public CustomAuthStateProvider(InMemoryAuthService authService)
        {
            this.authService = authService;
        }

        // claimsPrincipal = user 
        private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity()); 

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState authState = new AuthenticationState(claimsPrincipal);
            return Task.FromResult(authState);
        }

        public bool Login(string username, string password)
        {
            var user = authService.Login(username, password);

            if (user == null)
            {
                return false;
            }

            // create claims for the current user 
            var claimsCurrentUser = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }; 
            // create the identity
            var identity = new ClaimsIdentity(claimsCurrentUser, "CustomAuthentication");
            
            //create principal
            claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return true; 
        }

        public void Logout()
        {
            authService.Logout();
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
