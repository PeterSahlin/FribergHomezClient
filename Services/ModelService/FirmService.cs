using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FribergHomezClient.Services.ModelService
{
    public class FirmService : BaseHttpService, IFirmService
    {
        private readonly IClient client;
        public FirmService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        //get all firms
        public async Task<Response<List<Firm>>> GetFirmsAsync()
        {
            Response<List<Firm>> response;

            try
            {
                await GetBearerToken();
                var data = await client.FirmAllAsync();
                response = new Response<List<Firm>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<List<Firm>>(e);
            }
            return response;
        }

        //get firm by id
        public async Task<Response<Firm>> GetFirmByIdAsync(int firmId)
        {
            Response<Firm> response;

            try
            {
                await GetBearerToken();
                var data = await client.FirmGETAsync(firmId);
                response = new Response<Firm>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Firm>(e);
            }
            return response;
        }

        //create
        public async Task CreateFirmAsync (Firm firm)
        {
            try

            {

                await GetBearerToken();

                await client.FirmPOSTAsync(firm);

            }

            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)

            {

                // Handle the 404 error here

                Console.WriteLine("404 error occurred");

                // You can also return a custom error response or throw a custom exception

            }

            catch (Exception ex)

            {

                // Handle other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }



            //Response<Firm> response;
            //await GetBearerToken();
            //    await client.FirmPOSTAsync(firm);
            ////try
            ////{
            //    response = new Response<Firm>
            //    {                  
            //        Success = true
            //    };
            //}
            //catch (ApiException e)
            //{
            //    response = ConvertApiExceptions<Firm>(e);
            //}
            //return response;
        }



        ////update
        //public async Task<Response<Firm>> UpdateFirmAsync(Firm firm)
        //{

        //}

        //delete
        public async Task<Response<Firm>> DeleteFirmAsync(int firmId)
        {
            Response<Firm> response;
            await GetBearerToken();
            try
            {
                await client.FirmDELETEAsync(firmId);
                response = new Response<Firm>
                {
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Firm>(e);
            }
            return response;
        }
    }
}
