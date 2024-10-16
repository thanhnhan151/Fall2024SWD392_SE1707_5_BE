using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Corks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class CorkService : ICorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CorkService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCorkRequest request)
        {
            if (await _unitOfWork.Corks.CheckExistAsync(request.CorkType)) throw new Exception($"Cork with type: {request.CorkType} has already existed");

            var cork = new Cork { CorkType = request.CorkType };

            await _unitOfWork.Corks.AddEntityAsync(cork);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetCorkResponse>> GetAllAsync() => _mapper.Map<List<GetCorkResponse>>(await _unitOfWork.Corks.GetAllEntitiesAsync());
    }
}
