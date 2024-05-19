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
            var response = await httpClient.LoginAsync(loginModel);
            await localStorage.SetItemAsync("accessToken", response.Token);
            await localStorage.SetItemAsync("userId", response.UserId);
            await localStorage.SetItemAsync("email", response.Email);
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();
            return true;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
