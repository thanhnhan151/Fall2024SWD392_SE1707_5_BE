using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.WineCategories;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class WineCategoryService : IWineCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WineCategoryService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateWineCategoryAsync(CreateWineCategoryRequest createWineCategoryRequest)
        {
            await _unitOfWork.WineCategories.AddEntityAsync(_mapper.Map<WineCategory>(createWineCategoryRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetWineCategoryWithList?> GetAllWinesByWineCategoryIdAsync(long id)
            => _mapper.Map<GetWineCategoryWithList?>(await _unitOfWork.WineCategories.GetAllWinesByWineCategoryIdAsync(id));

        public async Task<List<GetWineCategoryResponse>> GetWineCategoryListAsync()
            => _mapper.Map<List<GetWineCategoryResponse>>(await _unitOfWork.WineCategories.GetAllEntitiesAsync());
    }
}
