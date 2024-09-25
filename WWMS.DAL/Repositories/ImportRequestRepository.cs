using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class ImportRequestRepository : GenericRepository<ImportRequest>, IImportRequestRepository
    {
        public ImportRequestRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }

}
