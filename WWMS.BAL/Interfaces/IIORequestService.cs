using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.IORequests;

namespace WWMS.BAL.Interfaces
{
    public interface IIORequestService
    {
        Task CreateIORequestsAsync(CreateIORequest createIORequest);

        Task<List<GetIORequest>> GetIORequestsListAsync();

        Task<GetIORequest?> GetIORequestsByIdAsync(long id);

        Task UpdateIORequestsAsync(UpdateIORequest updateIORequest);

        Task DisableIORequestsAsync(long id);
    }
}
