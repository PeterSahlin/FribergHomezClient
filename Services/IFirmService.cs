using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services
{
    public interface IFirmService
    {
        Task<Response<List<Firm>>> GetFirms();


    }
}
