using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Warehouses;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WarehouseService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateWarehouseAsync(CreateUpdateWarehouseRequest createWarehouseRequest)
        {
            await _unitOfWork.Warehouses.AddEntityAsync(_mapper.Map<Warehouse>(createWarehouseRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetWarehouseResponse?> GetWarehouseByIdAsync(long id) => _mapper.Map<GetWarehouseResponse?>(await _unitOfWork.Warehouses.GetEntityByIdAsync(id));

        public async Task<List<GetWarehouseResponse>> GetWarehouseListAsync() => _mapper.Map<List<GetWarehouseResponse>>(await _unitOfWork.Warehouses.GetAllEntitiesAsync());

        public async Task UpdateWarehouseAsync(CreateUpdateWarehouseRequest updateWarehouseRequest)
        {
            _unitOfWork.Warehouses.UpdateEntity(_mapper.Map<Warehouse>(updateWarehouseRequest));

            await _unitOfWork.CompleteAsync();
        }
    }
}
