using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Customers;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCustomerRequest request)
        {
            if (await _unitOfWork.Customers.CheckExistAsync(request.CustomerName)) throw new Exception($"Customer with name: {request.CustomerName} has already existed");

            var customer = new Customer { CustomerName = request.CustomerName };

            await _unitOfWork.Customers.AddEntityAsync(customer);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetCustomerResponse>> GetAllAsync() => _mapper.Map<List<GetCustomerResponse>>(await _unitOfWork.Customers.GetAllEntitiesAsync());
    }
}
