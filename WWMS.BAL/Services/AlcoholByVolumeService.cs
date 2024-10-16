using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.AlcoholByVolumes;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class AlcoholByVolumeService : IAlcoholByVolumeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlcoholByVolumeService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateVolumeRequest request)
        {
            if (await _unitOfWork.AlcoholByVolumes.CheckExistAsync(request.AlcoholByVolumeType)) throw new Exception($"Alcohol Volume with type: {request.AlcoholByVolumeType} has already existed");

            var volume = new AlcoholByVolume { AlcoholByVolumeType = request.AlcoholByVolumeType };

            await _unitOfWork.AlcoholByVolumes.AddEntityAsync(volume);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetVolumeResponse>> GetAllAsync() => _mapper.Map<List<GetVolumeResponse>>(await _unitOfWork.AlcoholByVolumes.GetAllEntitiesAsync());
    }
}
