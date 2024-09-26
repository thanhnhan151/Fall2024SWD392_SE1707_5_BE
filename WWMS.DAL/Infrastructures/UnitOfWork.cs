using Microsoft.Extensions.Logging;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;
using WWMS.DAL.Repositories;

namespace WWMS.DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WineWarehouseDbContext _context;

        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public IWineRepository Wines { get; private set; }

        public IImportRequestRepository Imports { get; private set; }

        public UnitOfWork(WineWarehouseDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);


            Wines = new WineRepository(_context, _logger);

            Imports = new ImportRequestRepository(context, _logger);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
