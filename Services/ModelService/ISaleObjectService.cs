using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelService
{
    public interface ISaleObjectService
    {
        Task<Response<List<SaleObject>>> GetSaleObjectAsync();

        Task<Response<SaleObject>> GetSaleObjectByIdAsync(int id);

        Task CreateSaleObjectAsync(SalesObjectDto saleObject);

        Task<Response<SaleObject>> DeleteSaleObjectAsync(int Id);

        Task UpdateSaleObjectAsync(SalesObjectDto saleObject);
    }
}
