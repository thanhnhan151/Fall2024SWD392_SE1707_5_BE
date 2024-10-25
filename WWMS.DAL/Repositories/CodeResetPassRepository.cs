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
        public Task<bool> CheckUsable(string verifiedCode)
        {
            throw new NotImplementedException();
        }

        public Task DisablePrevious(string username)
        {
            throw new NotImplementedException();
        }
    }
}