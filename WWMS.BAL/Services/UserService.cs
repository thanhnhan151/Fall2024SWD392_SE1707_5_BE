using AutoMapper;
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

        public UserService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<User>(createUserRequest);

            user.PasswordHash = BC.EnhancedHashPassword(createUserRequest.Password, 13);

            await _unitOfWork.Users.AddEntityAsync(user);

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
            _unitOfWork.Users.UpdateEntity(_mapper.Map<User>(updateUserRequest));

            await _unitOfWork.CompleteAsync();
        }
    }
}
