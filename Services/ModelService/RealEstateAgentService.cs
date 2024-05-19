using Blazored.LocalStorage;

using FribergHomezClient.Services.Base;
using System.Net;

namespace FribergHomezClient.Services.ModelService
{
    public class RealEstateAgentService : BaseHttpService, IRealEstateAgentService
    {
        //Peter

        //PROPERTIES

        private readonly IClient client;
        public RealEstateAgentService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }


        //METHODS

        //create
        public async Task CreateRealEstateAgentAsync(AgentDto agent)
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


        //get all
        public async Task<Response<List<RealEstateAgent>>> GetRealEstateAgentsAsync()
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

        //get by id
        public async Task<Response<RealEstateAgent>> GetRealEstateAgentByIdAsync(string agentId)
        {
            Response<RealEstateAgent> response;

            try
            {
                await GetBearerToken();
                var data = await client.RealEstateAgentGETAsync(agentId);
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

        //update
        public async Task UpdateRealEstateAgentAsync(RealEstateAgent agent)
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
        //delete (set inactive)
        public async Task<Response<RealEstateAgent>> DeleteRealEstateAgentAsync(string agentId)
        {
            Response<RealEstateAgent> response;
            await GetBearerToken();
            try
            {
                await client.RealEstateAgentDELETEAsync(agentId);
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

        //delete (permanently delete)
        public async Task<Response<RealEstateAgent>> DeleteAsync(string agentId)
        {
            Response<RealEstateAgent> response;
            await GetBearerToken();
            try
            {
                await client.DeleteAsync(agentId);
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
    }
}
