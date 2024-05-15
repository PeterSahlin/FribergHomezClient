using Blazored.LocalStorage;
using FribergHomezClient.Providers;
using FribergHomezClient.Services;
using FribergHomezClient.Services.Authentication;
using FribergHomezClient.Services.Base;
using FribergHomezClient.Services.ModelServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FribergHomezClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

         

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7259") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IClient, Client>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IFirmService, FirmService>();






            await builder.Build().RunAsync();
        }
    }
}
