using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Brands;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateBrandRequest request)
        {
            if (await _unitOfWork.Brands.CheckExistAsync(request.BrandName)) throw new Exception($"Brand with name : {request.BrandName} has already existed");

            var brand = new Brand { BrandName = request.BrandName };

            await _unitOfWork.Brands.AddEntityAsync(brand);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetBrandResponse>> GetAllAsync() => _mapper.Map<List<GetBrandResponse>>(await _unitOfWork.Brands.GetAllEntitiesAsync());
    }
}
