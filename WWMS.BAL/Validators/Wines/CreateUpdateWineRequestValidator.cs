using FluentValidation;
using WWMS.BAL.Models.Wines;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Validators.Wines
{
    public class CreateUpdateWineRequestValidator : AbstractValidator<CreateUpdateWineRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUpdateWineRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            #region Properties' Rule
            RuleFor(wine => wine.CountryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("CountryId must be greater than 0.")
                .MustAsync(async (countryId, cancellation) => await CheckCountryIdAsync(countryId))
                .WithMessage("CountryId does not exist");

            RuleFor(wine => wine.TasteId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("TasteId must be greater than 0.")
                .MustAsync(async (tasteId, cancellation) => await CheckTasteIdAsync(tasteId))
                .WithMessage("TasteId does not exist");

            RuleFor(wine => wine.ClassId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("ClassId must be greater than 0.")
                .MustAsync(async (classId, cancellation) => await CheckClassIdAsync(classId))
                .WithMessage("ClassId does not exist");

            RuleFor(wine => wine.QualificationId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("QualificationId must be greater than 0.")
                .MustAsync(async (qualificationId, cancellation) => await CheckQualificationIdAsync(qualificationId))
                .WithMessage("QualificationId does not exist");

            RuleFor(wine => wine.CorkId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("CorkId must be greater than 0.")
                .MustAsync(async (corkId, cancellation) => await CheckCorkIdAsync(corkId))
                .WithMessage("CorkId does not exist");

            RuleFor(wine => wine.BrandId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("BrandId must be greater than 0.")
                .MustAsync(async (brandId, cancellation) => await CheckBrandIdAsync(brandId))
                .WithMessage("BrandId does not exist");

            RuleFor(wine => wine.BottleSizeId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("BottleSizeId must be greater than 0.")
                .MustAsync(async (bottleSizeId, cancellation) => await CheckBottleSizeIdAsync(bottleSizeId))
                .WithMessage("BottleSizeId does not exist");

            RuleFor(wine => wine.AlcoholByVolumeId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("alcoholByVolumeId must be greater than 0.")
                .MustAsync(async (alcoholByVolumeId, cancellation) => await CheckAlcoholByVolumeIdAsync(alcoholByVolumeId))
                .WithMessage("alcoholByVolumeId does not exist");

            RuleFor(wine => wine.WineCategoryId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("wineCategoryId must be greater than 0.")
                .MustAsync(async (wineCategoryId, cancellation) => await CheckWineCategoryIdAsync(wineCategoryId))
                .WithMessage("wineCategoryId does not exist");
            #endregion
        }

        #region Check Functions
        private async Task<bool> CheckWineCategoryIdAsync(long id)
        {
            var role = await _unitOfWork.WineCategories.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckCountryIdAsync(long id)
        {
            var role = await _unitOfWork.Countries.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckTasteIdAsync(long id)
        {
            var role = await _unitOfWork.Tastes.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckClassIdAsync(long id)
        {
            var role = await _unitOfWork.Classes.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckQualificationIdAsync(long id)
        {
            var role = await _unitOfWork.Qualifications.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckCorkIdAsync(long id)
        {
            var role = await _unitOfWork.Corks.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckBrandIdAsync(long id)
        {
            var role = await _unitOfWork.Brands.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckBottleSizeIdAsync(long id)
        {
            var role = await _unitOfWork.BottleSizes.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }

        private async Task<bool> CheckAlcoholByVolumeIdAsync(long id)
        {
            var role = await _unitOfWork.AlcoholByVolumes.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }
        #endregion
    }
}
