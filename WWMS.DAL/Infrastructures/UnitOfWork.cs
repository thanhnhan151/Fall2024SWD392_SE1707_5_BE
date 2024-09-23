using Microsoft.Extensions.Logging;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Infrastructures
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WineWarehouseDbContext _context;

        public UnitOfWork(WineWarehouseDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
