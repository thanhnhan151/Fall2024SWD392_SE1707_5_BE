using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Qualifications;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QualificationService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateQualifcationRequest request)
        {
            if (await _unitOfWork.Qualifications.CheckExistAsync(request.QualificationType)) throw new Exception($"Qualification with type: {request.QualificationType} has already existed");

            var qual = new Qualification { QualificationType = request.QualificationType };

            await _unitOfWork.Qualifications.AddEntityAsync(qual);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetQualificationResponse>> GetAllAsync() => _mapper.Map<List<GetQualificationResponse>>(await _unitOfWork.Qualifications.GetAllEntitiesAsync());
    }
}
