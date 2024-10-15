using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Wines;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class WineService : IWineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WineService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateWineAsync(CreateUpdateWineRequest createWineRequest)
        {
            var wine = _mapper.Map<Wine>(createWineRequest);

            wine.Status = "Active";

            await _unitOfWork.Wines.AddEntityAsync(wine);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableWineAsync(long id)
        {
            await _unitOfWork.Wines.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetWineResponse?> GetWineByIdAsync(long id) => _mapper.Map<GetWineResponse>(await _unitOfWork.Wines.GetEntityByIdAsync(id));

        public async Task<List<GetWineResponse>> GetWineListAsync() => _mapper.Map<List<GetWineResponse>>(await _unitOfWork.Wines.GetAllEntitiesAsync());

        public async Task UpdateWineAsync(CreateUpdateWineRequest updateWineRequest)
        {
            _unitOfWork.Wines.UpdateEntity(_mapper.Map<Wine>(updateWineRequest));

            await _unitOfWork.CompleteAsync();
        }
    }
}
