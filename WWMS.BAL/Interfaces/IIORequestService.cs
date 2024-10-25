using WWMS.BAL.Models.IORequests;

namespace WWMS.BAL.Interfaces
{
    public interface IIORequestService
    {
        Task CreateIORequestsAsync(CreateIORequest createIORequest);

        Task<List<GetIORequest>> GetIORequestsListAsync();

        Task<GetIORequest?> GetIORequestsByIdAsync(long id);

        Task UpdateIORequestsAsync(UpdateIORequest updateIORequest, long id);

        Task DisableIORequestsAsync(long id);

        Task<List<GetIORequest>> GetAllEntitiesByIOStyle(string ioType);
    }
}
