using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Roles;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetRoleResponse>> GetAllAsync() => _mapper.Map<List<GetRoleResponse>>(await _unitOfWork.Roles.GetAllEntitiesAsync());
    }
}
