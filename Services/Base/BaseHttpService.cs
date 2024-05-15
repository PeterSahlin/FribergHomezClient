using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace FribergHomezClient.Services.Base
{
    public class BaseHttpService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IClient client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            this.localStorage = localStorage;
            this.client = client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new Response<Guid>()
                {
                    Message = "Validation error has occuered",
                    ValidationErrors = exception.Response,
                    Success = false
                };
            }
            if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found!", Success = false };
            }
            return new Response<Guid>() { Message = "Something went wrong, please try again!", Success = false };
        }
        public async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if (token == null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}

