using AutoMapper;
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

        public UserService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
            , IEmailService emailService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
        }

        private string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task CreateUserAsync(CreateUserRequest createUserRequest)
        {
            if (await _unitOfWork.Users.CheckExistUsernameAsync(createUserRequest.Username)) throw new Exception($"User with username: {createUserRequest.Username} has already existed");

            await _unitOfWork.Users.AddEntityAsync(await MappingCreateRequest(createUserRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableUserAsync(long id)
        {
            await _unitOfWork.Users.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetUserResponse?> GetUserByIdAsync(long id) => _mapper.Map<GetUserResponse?>(await _unitOfWork.Users.GetEntityByIdAsync(id));

        public async Task<List<GetUserResponse>> GetUserListAsync() => _mapper.Map<List<GetUserResponse>>(await _unitOfWork.Users.GetAllEntitiesAsync());

        public async Task<GetUserResponse?> LoginAsync(string username, string password) => _mapper.Map<GetUserResponse?>(await _unitOfWork.Users.LoginAsync(username, password));

        public async Task UpdateUserAsync(UpdateUserRequest updateUserRequest)
        {
            var user = await _unitOfWork.Users.GetEntityByIdAsync(updateUserRequest.Id) ?? throw new Exception($"User with id: {updateUserRequest.Id} does not exist");

            _unitOfWork.Users.UpdateEntity(MappingUpdateRequest(updateUserRequest));

            await _unitOfWork.CompleteAsync();
        }

        private async Task<User> MappingCreateRequest(CreateUserRequest createUserRequest)
        {
            var password = GenerateRandomPassword();

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

        private User MappingUpdateRequest(UpdateUserRequest updateUserRequest)
        {
            var user = new User
            {
                FirstName = updateUserRequest.FirstName,
                LastName = updateUserRequest.LastName,
                PhoneNumber = updateUserRequest.PhoneNumber,
                Email = updateUserRequest.Email,
                ProfileImageUrl = updateUserRequest.ProfileImageUrl
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) user.UpdatedBy = userName.Value;

            user.UpdatedTime = DateTime.Now;

            return user;
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(resetPasswordRequest.Username) ?? throw new Exception($"Username: {resetPasswordRequest.Username} does not exist");

            if (!BC.EnhancedVerify(resetPasswordRequest.Password, user.PasswordHash)) throw new Exception($"Invalid password");

            if (!resetPasswordRequest.Password.Equals(resetPasswordRequest.ConfirmPassword)) throw new Exception($"Confirm password does not match");

            user.PasswordHash = BC.EnhancedHashPassword(resetPasswordRequest.NewPassword, 13);

            _unitOfWork.Users.UpdateEntity(user);

            await _unitOfWork.CompleteAsync();
        }
    }
}
