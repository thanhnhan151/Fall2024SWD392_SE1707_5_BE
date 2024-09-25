using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Users;
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

        public async Task<List<GetUserResponse>> GetUserListAsync() => _mapper.Map<List<GetUserResponse>>(await _unitOfWork.Users.GetAllEntitiesAsync());
    }
}
