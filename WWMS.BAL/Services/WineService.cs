using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Wines;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class WineService : IWineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WineService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateWineAsync(CreateUpdateWineRequest createWineRequest)
        {
            await _unitOfWork.Wines.AddEntityAsync(MappingCreateRequest(createWineRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableWineAsync(long id)
        {
            await _unitOfWork.Wines.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetWineDetailResponse?> GetWineByIdAsync(long id) => _mapper.Map<GetWineDetailResponse>(await _unitOfWork.Wines.GetByIdWithIncludeAsync(id));

        public async Task<List<GetWineResponse>> GetWineListAsync() => _mapper.Map<List<GetWineResponse>>(await _unitOfWork.Wines.GetAllEntitiesAsync());

        public async Task UpdateWineAsync(CreateUpdateWineRequest updateWineRequest)
        {
            var wine = await _unitOfWork.Wines.GetEntityByIdAsync(updateWineRequest.Id) ?? throw new Exception($"Wine with id: {updateWineRequest.Id} does not exist");

            _unitOfWork.Wines.UpdateEntity(MappingUpdateRequest(updateWineRequest));

            await _unitOfWork.CompleteAsync();
        }

        private Wine MappingCreateRequest(CreateUpdateWineRequest createWineRequest)
        {
            var wine = new Wine
            {
                WineName = createWineRequest.WineName,
                AvailableStock = createWineRequest.AvailableStock,
                Description = createWineRequest.Description,
                ImageUrl = createWineRequest.ImageUrl,
                Supplier = createWineRequest.Supplier,
                MFD = createWineRequest.MFD,
                ImportPrice = createWineRequest.ImportPrice,
                ExportPrice = createWineRequest.ExportPrice,
                WineCategoryId = createWineRequest.CategoryId,
                CountryId = createWineRequest.CountryId,
                TasteId = createWineRequest.TasteId,
                ClassId = createWineRequest.ClassId,
                QualificationId = createWineRequest.QualificationId,
                CorkId = createWineRequest.CorkId,
                BrandId = createWineRequest.BrandId,
                BottleSizeId = createWineRequest.BottleSizeId,
                AlcoholByVolumeId = createWineRequest.AlcoholByVolumeId
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) wine.CreatedBy = userName.Value;

            wine.CreatedTime = DateTime.Now;

            wine.Status = "Active";

            return wine;
        }

        private Wine MappingUpdateRequest(CreateUpdateWineRequest updateWineRequest)
        {
            var wine = new Wine
            {
                WineName = updateWineRequest.WineName,
                AvailableStock = updateWineRequest.AvailableStock,
                Description = updateWineRequest.Description,
                ImageUrl = updateWineRequest.ImageUrl,
                Supplier = updateWineRequest.Supplier,
                MFD = updateWineRequest.MFD,
                ImportPrice = updateWineRequest.ImportPrice,
                ExportPrice = updateWineRequest.ExportPrice,
                WineCategoryId = updateWineRequest.CategoryId,
                CountryId = updateWineRequest.CountryId,
                TasteId = updateWineRequest.TasteId,
                ClassId = updateWineRequest.ClassId,
                QualificationId = updateWineRequest.QualificationId,
                CorkId = updateWineRequest.CorkId,
                BrandId = updateWineRequest.BrandId,
                BottleSizeId = updateWineRequest.BottleSizeId,
                AlcoholByVolumeId = updateWineRequest.AlcoholByVolumeId
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) wine.UpdatedBy = userName.Value;

            wine.UpdatedTime = DateTime.Now;

            return wine;
        }
    }
}
