using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class CodeResetPassRepository : GenericRepository<CodeResetPass>, ICodeResetPassRepository
    {
        public CodeResetPassRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }
        public async Task<bool> CheckUsable(string verifiedCode)
        {
            throw new NotImplementedException();
        }

        public async Task DisablePrevious(string username)
        {
            //TODO: implement in the worker service
        }
    }
}