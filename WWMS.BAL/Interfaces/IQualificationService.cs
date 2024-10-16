using WWMS.BAL.Models.Qualifications;

namespace WWMS.BAL.Interfaces
{
    public interface IQualificationService
    {
        Task<List<GetQualificationResponse>> GetAllAsync();
        Task CreateAsync(CreateQualifcationRequest request);
    }
}
