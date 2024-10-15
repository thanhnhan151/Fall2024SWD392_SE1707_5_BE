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
            await _unitOfWork.Wines.AddEntityAsync(MappingCreateUpdateRequest(createWineRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableWineAsync(long id)
        {
            await _unitOfWork.Wines.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetWineDetailResponse?> GetWineByIdAsync(long id) => _mapper.Map<GetWineDetailResponse>(await _unitOfWork.Wines.GetEntityByIdAsync(id));

        public async Task<List<GetWineResponse>> GetWineListAsync() => _mapper.Map<List<GetWineResponse>>(await _unitOfWork.Wines.GetAllEntitiesAsync());

        public async Task UpdateWineAsync(CreateUpdateWineRequest updateWineRequest)
        {
            _unitOfWork.Wines.UpdateEntity(MappingCreateUpdateRequest(updateWineRequest));

            await _unitOfWork.CompleteAsync();
        }

        private Wine MappingCreateUpdateRequest(CreateUpdateWineRequest createUpdateWineRequest)
        {
            var wine = new Wine
            {
                WineName = createUpdateWineRequest.WineName,
                AvailableStock = createUpdateWineRequest.AvailableStock,
                Description = createUpdateWineRequest.Description,
                ImageUrl = createUpdateWineRequest.ImageUrl,
                Supplier = createUpdateWineRequest.Supplier,
                MFD = createUpdateWineRequest.MFD,
                ImportPrice = createUpdateWineRequest.ImportPrice,
                ExportPrice = createUpdateWineRequest.ExportPrice,
                WineCategoryId = createUpdateWineRequest.CategoryId,
                CountryId = createUpdateWineRequest.CountryId,
                TasteId = createUpdateWineRequest.TasteId,
                ClassId = createUpdateWineRequest.ClassId,
                QualificationId = createUpdateWineRequest.QualificationId,
                CorkId = createUpdateWineRequest.CorkId,
                BrandId = createUpdateWineRequest.BrandId,
                BottleSizeId = createUpdateWineRequest.BottleSizeId,
                AlcoholByVolumeId = createUpdateWineRequest.AlcoholByVolumeId
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (createUpdateWineRequest.Id > 0)
            {
                if (userName != null) wine.UpdatedBy = userName.Value;

                wine.UpdatedTime = DateTime.Now;

                return wine;
            }

            if (userName != null) wine.CreatedBy = userName.Value;

            wine.CreatedTime = DateTime.Now;

            wine.Status = "Active";

            return wine;
        }
    }
}
