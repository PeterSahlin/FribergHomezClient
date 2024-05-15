using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelServices
{
    public class FirmService : BaseHttpService, IFirmService
    {
        private readonly IClient client;
        public FirmService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }
        public async Task<Response<List<Firm>>> GetFirms()
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
    }
}
