using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;
using WWMS.DAL.Repositories;

namespace WWMS.DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly WineWarehouseDbContext _context;

        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public IWineRepository Wines { get; private set; }

        public IRoomRepository Rooms { get; private set; }

        public IWineCategoryRepository WineCategories { get; private set; }

        public IIORequestRepository IIORequests { get; private set; }

        public IRoleRepository Roles { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public ITasteRepository Tastes { get; private set; }

        public IClassRepository Classes { get; private set; }

        public IQualificationRepository Qualifications { get; private set; }

        public ICorkRepository Corks { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public IBottleSizeRepository BottleSizes { get; private set; }

        public IAlcoholByVolumeRepository AlcoholByVolumes { get; private set; }

        public ISuplierRepository Supliers { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public ICodeResetPassRepository CodeResetPasses { get; private set; }

        public ICheckRequestDetailRepository CheckRequestDetails { get; private set; }

        public ICheckRequestRepository CheckRequests { get; private set; }

        public UnitOfWork(WineWarehouseDbContext context
            , ILoggerFactory loggerFactory
            , IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _context = context;

            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger, _httpContextAccessor);

            Wines = new WineRepository(_context, _logger, _httpContextAccessor);

            WineCategories = new WineCategoryRepository(_context, _logger, _httpContextAccessor);

            Rooms = new RoomRepository(_context, _logger, _httpContextAccessor);

            IIORequests = new IORequestRepository(_context, _logger, _httpContextAccessor);

            Roles = new RoleRepository(_context, _logger, _httpContextAccessor);

            Countries = new CountryRepository(_context, _logger, _httpContextAccessor);

            Tastes = new TasteRepository(_context, _logger, _httpContextAccessor);

            Classes = new ClassRepository(_context, _logger, _httpContextAccessor);

            Qualifications = new QualificationRepository(_context, _logger, _httpContextAccessor);

            Corks = new CorkRepository(_context, _logger, _httpContextAccessor);

            Brands = new BrandRepository(_context, _logger, _httpContextAccessor);

            BottleSizes = new BottleSizeRepository(_context, _logger, _httpContextAccessor);

            AlcoholByVolumes = new AlcoholByVolumeRepository(_context, _logger, _httpContextAccessor);

            Supliers = new SuplierRepository(_context, _logger, _httpContextAccessor);

            Customers = new CustomerRepository(_context, _logger, _httpContextAccessor);

            CodeResetPasses = new CodeResetPassRepository(_context, _logger, _httpContextAccessor);

            CheckRequests = new CheckRequestRepository(_context, _logger, _httpContextAccessor);

            CheckRequestDetails = new CheckRequestDetailRepository(_context, _logger, _httpContextAccessor);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
