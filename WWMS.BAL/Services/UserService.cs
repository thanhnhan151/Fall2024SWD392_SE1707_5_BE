using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Helpers;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Users;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;
        private readonly IUploadFileService _uploadFileService;

        public UserService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
            , IEmailService emailService
            , IValidator<CreateUserRequest> createUserRequestValidator
            , IUploadFileService uploadFileService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _createUserRequestValidator = createUserRequestValidator;
            _uploadFileService = uploadFileService;
        }

        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task CreateUserAsync(CreateUserRequest createUserRequest)
        {
            if (await _unitOfWork.Users.CheckExistUsernameAsync(createUserRequest.Username)) throw new Exception($"User with username: {createUserRequest.Username} has already existed");

            if (await _unitOfWork.Users.CheckExistEmailAsync(createUserRequest.Email)) throw new Exception($"User with email: {createUserRequest.Email} has already existed");

            var validationResult = await _createUserRequestValidator.ValidateAsync(createUserRequest);

            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _unitOfWork.Users.AddEntityAsync(await MappingCreateRequest(createUserRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableUserAsync(long id)
        {
            await _unitOfWork.Users.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetUserResponse?> GetUserByIdAsync(long id) => _mapper.Map<GetUserResponse?>(await _unitOfWork.Users.GetUserInfoAsync(id));

        public async Task<List<GetUserResponse>> GetUserListAsync() => _mapper.Map<List<GetUserResponse>>(await _unitOfWork.Users.GetAllEntitiesAsync());

        public async Task<GetUserResponse?> LoginAsync(string username, string password) => _mapper.Map<GetUserResponse?>(await _unitOfWork.Users.LoginAsync(username, password));

        public async Task UpdateUserAsync(long id, UpdateUserRequest updateUserRequest)
        {
            var user = await _unitOfWork.Users.GetEntityByIdAsync(id) ?? throw new Exception($"User with id: {id} does not exist");

            if (await _unitOfWork.Users.CheckExistEmailAsync(updateUserRequest.Email)) throw new Exception($"User with email: {updateUserRequest.Email} has already existed");

            _unitOfWork.Users.UpdateEntity(MappingUpdateRequest(updateUserRequest, user));

            await _unitOfWork.CompleteAsync();
        }

        private async Task<User> MappingCreateRequest(CreateUserRequest createUserRequest)
        {
            var password = GenRandomString();

            var user = new User
            {
                Username = createUserRequest.Username,
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                PhoneNumber = createUserRequest.PhoneNumber,
                Email = createUserRequest.Email,
                RoleId = createUserRequest.RoleId,
                Status = "Active"
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) user.CreatedBy = userName.Value;

            user.CreatedTime = DateTime.Now;

            user.PasswordHash = BC.EnhancedHashPassword(password, 13);

            if (user == null) return new User();

            var mailRequest = new MailRequest
            {
                ToEmail = user.Email,
                Subject = "Welcome to Wine Warehouse System",
                Body = $"Username: {user.Username} Password: {password}"
            };

            await _emailService.SendEmailAsync(mailRequest);

            return user;
        }

        private User MappingUpdateRequest(UpdateUserRequest updateUserRequest, User user)
        {

            user.FirstName = updateUserRequest.FirstName;
            user.LastName = updateUserRequest.LastName;
            user.PhoneNumber = updateUserRequest.PhoneNumber;
            user.Email = updateUserRequest.Email;
            user.UpdatedTime = DateTime.Now;

            return user;
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(resetPasswordRequest.Username) ?? throw new Exception($"Username: {resetPasswordRequest.Username} does not exist");

            user.PasswordHash = BC.EnhancedHashPassword(resetPasswordRequest.NewPass, 13);

            _unitOfWork.Users.UpdateEntity(user);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest)
        {
            var userName = _httpContextAccessor
                            .HttpContext.User
                            .Claims.FirstOrDefault(x => x.Type
                            .Equals("Username", StringComparison.CurrentCultureIgnoreCase))
                            .Value;
            var user = await _unitOfWork.Users.GetByUsernameAsync(userName);

            if (!BC.EnhancedVerify(updatePasswordRequest.OldPass, user.PasswordHash))
            {
                throw new Exception("Wrong old password");
            }
            user.PasswordHash = BC.EnhancedHashPassword(updatePasswordRequest.NewPass);
            _unitOfWork.Users.UpdateEntity(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task SendCodeResetPassAsync(SendCodeResetPassRequest sendCodeResetPassRequest)
        {

            var user = await _unitOfWork.Users.GetByUsernameAsync(sendCodeResetPassRequest.Username);
            if ((user is null) || !(user.Email.Equals(sendCodeResetPassRequest.Email)))
            {
                throw new Exception("username or email not true");
            }

            string randomCodeReset = GenRandomString();
            var CodeResetPass = new CodeResetPass
            {
                CodeVerified = randomCodeReset,
                Username = sendCodeResetPassRequest.Email,
            };
            //save to db
            await _unitOfWork.CodeResetPasses.AddEntityAsync(CodeResetPass);

            var mailRequest = new MailRequest
            {
                ToEmail = sendCodeResetPassRequest.Username,
                Subject = "RESET PASSWORD WINE WAREHOUSE SYSTEM",
                Body = randomCodeReset
            };

            await _emailService.SendEmailAsync(mailRequest);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetStaffResponse>> GetStaffAsync()
        => _mapper.Map<List<GetStaffResponse>>(await _unitOfWork.Users.GetAllStaffAsync());

        public async Task<string> UploadProfileImageAsync(IFormFile file)
        {
            string imgUrl = await _uploadFileService.UploadImage(file);
            var userName = _httpContextAccessor
            .HttpContext.User
            .Claims.FirstOrDefault(x => x.Type
            .Equals("Username", StringComparison.CurrentCultureIgnoreCase))
            .Value;

            User user = await _unitOfWork.Users.GetByUsernameAsync(userName);
            user.ProfileImageUrl = imgUrl;
            _unitOfWork.Users.UpdateEntity(user);
            _unitOfWork.CompleteAsync();
            return imgUrl;
        }
    }
}
