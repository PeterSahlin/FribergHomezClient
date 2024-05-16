using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;
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
            //Response<Firm> response;
                await GetBearerToken();
                await client.FirmPOSTAsync(firm);
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
