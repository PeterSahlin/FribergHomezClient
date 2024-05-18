using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelService
{
    public interface IRealEstateAgentService
    {
        Task<Response<List<RealEstateAgent>>> GetAgentsAsync();

        Task<Response<RealEstateAgent>> GetAgentByIdAsync(string id);

        Task CreateAgentAsync(AgentDto agent);

        Task<Response<RealEstateAgent>> DeleteAgentAsync(string Id);

        Task UpdateAgentAsync(RealEstateAgent agent);
    }
}
