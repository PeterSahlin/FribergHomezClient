using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginDTO loginModel);
        public Task Logout();


    }
}
