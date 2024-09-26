using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.ImportRequest;
using WWMS.BAL.Models.Users;

namespace WWMS.BAL.Interfaces
{
    public interface IImportRequestService
    {
        Task<List<GetImportRequestRespone>> GetImportRequestAsync();

        Task<GetImportRequestRespone> GetImportRequestByIdAsync(long Import_id);

        Task CreateImportRequestAnync(CreateImportRequest Import);

        Task UpdateImportRequestAsync(UpdateImportRequest Import);

        Task DisableImportRequestAsync(long id);
    }
}
