using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;
using System.Net;

namespace FribergHomezClient.Services.ModelService
{
    public class RealEstateAgentService : BaseHttpService, IRealEstateAgentService
    {
        private readonly IClient client;
        public RealEstateAgentService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<Response<List<RealEstateAgent>>> GetAgentsAsync()
        {
            Response<List<RealEstateAgent>> response;

            try
            {
                await GetBearerToken();
                var data = await client.RealEstateAgentAllAsync();
                response = new Response<List<RealEstateAgent>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<List<RealEstateAgent>>(e);
            }
            return response;
        }

        public async Task<Response<RealEstateAgent>> GetAgentByIdAsync(string id)
        {
            Response<RealEstateAgent> response;

            try
            {
                await GetBearerToken();
                var data = await client.RealEstateAgentGETAsync(id);
                response = new Response<RealEstateAgent>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<RealEstateAgent>(e);
            }
            return response;
        }

        public async Task CreateAgentAsync(AgentDto agent)
        {
            try
            {
                await GetBearerToken();
                await client.RealEstateAgentPOSTAsync(agent);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("404 error occurred");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public async Task<Response<RealEstateAgent>> DeleteAgentAsync(string Id)
        {
            Response<RealEstateAgent> response;
            await GetBearerToken();
            try
            {
                await client.RealEstateAgentDELETEAsync(Id);
                response = new Response<RealEstateAgent>
                {
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<RealEstateAgent>(e);
            }
            return response;
        }

        public async Task UpdateAgentAsync(RealEstateAgent agent)
        {
            try
            {
                await GetBearerToken();
                await client.RealEstateAgentPUTAsync(agent);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("404 error occurred");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
