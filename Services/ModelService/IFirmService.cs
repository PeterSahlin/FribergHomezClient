using FribergHomezClient.Services.Base;
using System.Threading.Tasks;

namespace FribergHomezClient.Services.ModelService
{
    public interface IFirmService
    {
        Task<Response<List<Firm>>> GetFirmsAsync();

        Task<Response<Firm>> GetFirmByIdAsync(int firmId);

        Task CreateFirmAsync(Firm firm);

        Task<Response<Firm>> DeleteFirmAsync(int firmId);

        Task UpdateFirmAsync(int id, Firm firm);


    }
}
