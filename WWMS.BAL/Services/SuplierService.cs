using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Supliers;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class SuplierService : ISuplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SuplierService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateSuplierRequest request)
        {
            if (await _unitOfWork.Supliers.CheckExistAsync(request.SuplierName)) throw new Exception($"Suplier with name: {request.SuplierName} has already existed");

            var suplier = new Suplier { SuplierName = request.SuplierName };

            await _unitOfWork.Supliers.AddEntityAsync(suplier);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetSuplierResponse>> GetAllAsync() => _mapper.Map<List<GetSuplierResponse>>(await _unitOfWork.Supliers.GetAllEntitiesAsync());
    }
}
