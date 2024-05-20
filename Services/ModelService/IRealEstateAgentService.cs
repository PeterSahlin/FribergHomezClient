using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelService
{
    public interface IRealEstateAgentService
    {
        //Peter

        //create
        Task CreateRealEstateAgentAsync(AgentDto agent);

        //read
        Task<Response<List<RealEstateAgent>>> GetRealEstateAgentsAsync();

        Task<Response<RealEstateAgent>> GetRealEstateAgentByIdAsync(string agentId);

        //update
        Task UpdateRealEstateAgentAsync(RealEstateAgent agent);


        //delete (set inactive)
        Task<Response<RealEstateAgent>> DeleteRealEstateAgentAsync(string agentId);

        //delete (permanently)
        Task<Response<RealEstateAgent>> DeleteAsync(string agentId);

    }
}
