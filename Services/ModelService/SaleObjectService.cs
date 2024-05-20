using FribergHomezClient.Services.Base;
using Blazored.LocalStorage;
using System.Net;

namespace FribergHomezClient.Services.ModelService
{
    public class SaleObjectService : BaseHttpService, ISaleObjectService
    {
        //Henrik
        private readonly IClient client;
        public SaleObjectService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }
        public async Task<Response<List<SaleObject>>> GetSaleObjectAsync()
        {
            Response<List<SaleObject>> response;

            try
            {
                await GetBearerToken();
                var data = await client.SalesObjectAllAsync();
                response = new Response<List<SaleObject>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<List<SaleObject>>(e);
            }
            return response;
        }

        public async Task<Response<SaleObject>> GetSaleObjectByIdAsync(int id)
        {
            Response<SaleObject> response;

            try
            {
                await GetBearerToken();
                var data = await client.SalesObjectGETAsync(id);
                response = new Response<SaleObject>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<SaleObject>(e);
            }
            return response;
        }

        public async Task CreateSaleObjectAsync(SalesObjectDto saleObject)
        {
            try
            {
                await GetBearerToken();
                await client.SalesObjectPOSTAsync(saleObject);
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

        public async Task<Response<SaleObject>> DeleteSaleObjectAsync(int Id)
        {
            Response<SaleObject> response;
            await GetBearerToken();
            try
            {
                await client.SalesObjectDELETEAsync(Id);
                response = new Response<SaleObject>
                {
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<SaleObject>(e);
            }
            return response;
        }

        public async Task UpdateSaleObjectAsync(SalesObjectDto saleObject)
        {
            try
            {
                await GetBearerToken();
                await client.SalesObjectPUTAsync(saleObject);
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
