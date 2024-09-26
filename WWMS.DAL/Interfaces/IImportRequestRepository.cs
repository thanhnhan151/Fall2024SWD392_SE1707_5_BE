using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IImportRequestRepository : IGenericRepository<ImportRequest>
    {
        Task DisableAsync(long id);
    }
}
