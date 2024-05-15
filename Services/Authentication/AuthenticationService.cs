using Blazored.LocalStorage;
using FribergHomezClient.Providers;
using FribergHomezClient.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace FribergHomezClient.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginDTO loginModel)
        {
            try
            {
                var response = await httpClient.LoginAsync(loginModel);
                if (response.Token != null)
                {
                    await localStorage.SetItemAsync("accessToken", response.Token);
                    await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
            }
            return false;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
