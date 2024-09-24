using Microsoft.Extensions.Logging;
using WWMS.DAL.Models;

namespace WWMS.DAL.Infrastructures
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SwdFa24WineWarehouseVer02Context _context;

        public UnitOfWork(SwdFa24WineWarehouseVer02Context context, ILoggerFactory loggerFactory)
        {
            _context = context;
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
