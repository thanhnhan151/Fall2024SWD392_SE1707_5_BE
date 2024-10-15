using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public UserService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
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

            await _unitOfWork.Users.AddEntityAsync(MappingCreateRequest(createUserRequest));

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

        private User MappingCreateRequest(CreateUserRequest createUserRequest)
        {
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

            user.PasswordHash = BC.EnhancedHashPassword(GenerateRandomPassword(), 13);

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
    }
}
