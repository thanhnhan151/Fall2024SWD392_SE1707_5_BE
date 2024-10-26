using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.IORequests.IOrequestdetails;

namespace WWMS.BAL.Interfaces
{
    public interface IIORequestService
    {
        Task CreateIORequestsAsync(CreateIORequest createIORequest);

        Task<List<GetIORequest>> GetIORequestsListAsync();

        Task<GetIORequest?> GetIORequestsByIdAsync(long id);

        Task DoneIORequestsAsync(long id);

        Task UpdateManyIORequestsAsync(UpdateIORequest updateIORequest, long id);

        Task CreateManyIORequestDetailsByIdAsync(CreateDetailsById updateIORequest, long id);

        Task UpdateManyIORequestDetailsByIdAsync(UpdateDetailsById updateIORequest, long id);

        Task RemoveIORequestDetailByIdAsync(long ioRequestId, long detailId);


         Task DisableIORequestsAsync(long id);

        Task<List<GetIORequest>> GetAllEntitiesByIOStyle(string ioType);
    }
}
