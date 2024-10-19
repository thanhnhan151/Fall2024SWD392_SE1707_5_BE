using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ICheckRequestDetailRepository : IGenericRepository<CheckRequestDetail>
    {
        Task<ICollection<CheckRequestDetail>> GetAllCheckRequestDetailsByReporterNameAsync(string reporterName);
    }
}