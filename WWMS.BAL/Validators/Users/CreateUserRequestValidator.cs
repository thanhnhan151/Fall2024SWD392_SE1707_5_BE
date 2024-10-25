using FluentValidation;
using WWMS.BAL.Models.Users;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Validators.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(user => user.RoleId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("RoleId must be greater than 0.")
                .MustAsync(async (roleId, cancellation) => await CheckRoleIdAsync(roleId))
                .WithMessage("RoleId does not exist .");
        }

        private async Task<bool> CheckRoleIdAsync(long id)
        {
            var role = await _unitOfWork.Roles.GetEntityByIdAsync(id);

            if (role == null) return false;

            return true;
        }
    }
}
