using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.BottleSizes;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class BottleSizeService : IBottleSizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BottleSizeService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateBottleSizeRequest request)
        {
            if (await _unitOfWork.BottleSizes.CheckExistAsync(request.BottleSizeType)) throw new Exception($"Bottle size with type: {request.BottleSizeType} has already existed");

            var bottleSize = new BottleSize { BottleSizeType = request.BottleSizeType };

            await _unitOfWork.BottleSizes.AddEntityAsync(bottleSize);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetBottleSizeResponse>> GetAllAsync() => _mapper.Map<List<GetBottleSizeResponse>>(await _unitOfWork.BottleSizes.GetAllEntitiesAsync());
    }
}
