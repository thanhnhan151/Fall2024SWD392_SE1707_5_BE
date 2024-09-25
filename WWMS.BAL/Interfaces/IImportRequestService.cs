using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.ImportRequest.Request;
using WWMS.BAL.Models.ImportRequest.Responnse;
using WWMS.BAL.Models.Users;

namespace WWMS.BAL.Interfaces
{
    public interface IImportRequestService
    {
        Task<List<GetImportRequestRespone>> GetImportRequestAsync();

        Task<GetImportRequestRespone> GetImportRequestByIdAsync(long Import_id);

        Task<GetImportRequestRespone> CreateImportRequestAnync(ImportRequestRes Import);

    }
}