
﻿using Microsoft.AspNetCore.Http;

﻿using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class IORequestDetailRepository : GenericRepository<IORequestDetail>, IIORequestDetailRepository
    {
        public IORequestDetailRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }

        public override async Task<ICollection<IORequestDetail>> GetAllEntitiesAsync() => await _dbSet.Include(w => w.IORequest).ToListAsync();
    }
}
