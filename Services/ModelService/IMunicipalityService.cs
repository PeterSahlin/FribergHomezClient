using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelService
{
    public interface IMunicipalityService
    {
        Task<Response<List<Municipality>>> GetMunicipalitiesAsync();

        Task<Response<Municipality>> GetMunicipalityByIdAsync(int municipalityid);

        Task CreateMunicipalityAsync(Municipality municipality);

        Task<Response<Municipality>> DeleteMunicipalityAsync(int municipalityid);

        Task UpdateMunicipalityAsync(Municipality municipality);


    }
}
