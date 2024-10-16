using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Countries;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCountryRequest request)
        {
            if (await _unitOfWork.Countries.CheckExistAsync(request.CountryName)) throw new Exception($"Country with name: {request.CountryName} has already existed");

            var country = new Country { CountryName = request.CountryName };

            await _unitOfWork.Countries.AddEntityAsync(country);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetCountryResponse>> GetAllAsync() => _mapper.Map<List<GetCountryResponse>>(await _unitOfWork.Countries.GetAllEntitiesAsync());
    }
}
