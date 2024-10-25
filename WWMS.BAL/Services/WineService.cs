using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateUpdateWineRequest> _createUpdateWineRequestValidator;

        public WineService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
            , IValidator<CreateUpdateWineRequest> createUpdateWineRequestValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _createUpdateWineRequestValidator = createUpdateWineRequestValidator;
        }

        public async Task CreateWineAsync(CreateUpdateWineRequest createWineRequest)
        {
            var validationResult = await _createUpdateWineRequestValidator.ValidateAsync(createWineRequest);

            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

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

        public async Task UpdateWineAsync(long id, CreateUpdateWineRequest updateWineRequest)
        {
            var wine = await _unitOfWork.Wines.GetEntityByIdAsync(id) ?? throw new Exception($"Wine with id: {id} does not exist");

            var validationResult = await _createUpdateWineRequestValidator.ValidateAsync(updateWineRequest);

            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            _unitOfWork.Wines.UpdateEntity(MappingUpdateRequest(wine, updateWineRequest));

            await _unitOfWork.CompleteAsync();
        }

        private Wine MappingCreateRequest(CreateUpdateWineRequest createWineRequest)
        {
            var wine = new Wine
            {
                WineName = createWineRequest.WineName,
                Description = createWineRequest.Description,
                ImageUrl = createWineRequest.ImageUrl,
                MFD = createWineRequest.MFD,
                ImportPrice = createWineRequest.ImportPrice,
                ExportPrice = createWineRequest.ExportPrice,
                WineCategoryId = createWineRequest.WineCategoryId,
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

        private Wine MappingUpdateRequest(Wine wine, CreateUpdateWineRequest updateWineRequest)
        {
            wine.WineName = updateWineRequest.WineName;
            wine.Description = updateWineRequest.Description;
            wine.ImageUrl = updateWineRequest.ImageUrl;
            wine.MFD = updateWineRequest.MFD;
            wine.ImportPrice = updateWineRequest.ImportPrice;
            wine.ExportPrice = updateWineRequest.ExportPrice;
            wine.WineCategoryId = updateWineRequest.WineCategoryId;
            wine.CountryId = updateWineRequest.CountryId;
            wine.TasteId = updateWineRequest.TasteId;
            wine.ClassId = updateWineRequest.ClassId;
            wine.QualificationId = updateWineRequest.QualificationId;
            wine.CorkId = updateWineRequest.CorkId;
            wine.BrandId = updateWineRequest.BrandId;
            wine.BottleSizeId = updateWineRequest.BottleSizeId;
            wine.AlcoholByVolumeId = updateWineRequest.AlcoholByVolumeId;

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) wine.UpdatedBy = userName.Value;

            wine.UpdatedTime = DateTime.Now;

            return wine;
        }
    }
}
