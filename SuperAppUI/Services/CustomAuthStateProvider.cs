using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace SuperApp_UI.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }



        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Check for token in local storage
            var token = await _localStorage.GetItemAsStringAsync("jwtToken");

            ClaimsIdentity identity;

            if (!string.IsNullOrEmpty(token))
            {
                // You can add claims from token here if needed
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "User")
                }, "jwtAuth");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }


        public async Task MarkUserAsAuthenticatedAsync(string token)
        {
            await _localStorage.SetItemAsStringAsync("jwtToken", token);
            var identity = new ClaimsIdentity(new[]
            {
        new Claim(ClaimTypes.Name, "User")
    }, "jwtAuth");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOutAsync()
        {
            await _localStorage.RemoveItemAsync("jwtToken");
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }


        public void NotifyUserAuthentication(string token)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "User")
            }, "jwtAuth");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
