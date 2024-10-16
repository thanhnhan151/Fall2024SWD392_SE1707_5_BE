using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Tastes;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class TasteService : ITasteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasteService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateTasteRequest request)
        {
            if (await _unitOfWork.Tastes.CheckExistAsync(request.TasteType)) throw new Exception($"Taste with type: {request.TasteType} has already existed");

            var taste = new Taste { TasteType = request.TasteType };

            await _unitOfWork.Tastes.AddEntityAsync(taste);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetTasteResponse>> GetAllAsync() => _mapper.Map<List<GetTasteResponse>>(await _unitOfWork.Tastes.GetAllEntitiesAsync());
    }
}
