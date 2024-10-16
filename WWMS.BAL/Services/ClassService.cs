using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Classes;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateClassRequest request)
        {
            if (await _unitOfWork.Classes.CheckExistAsync(request.ClassType)) throw new Exception($"Class with type: {request.ClassType} has already existed");

            var temp = new Class { ClassType = request.ClassType };

            await _unitOfWork.Classes.AddEntityAsync(temp);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetClassResponse>> GetAllAsync() => _mapper.Map<List<GetClassResponse>>(await _unitOfWork.Classes.GetAllEntitiesAsync());
    }
}
