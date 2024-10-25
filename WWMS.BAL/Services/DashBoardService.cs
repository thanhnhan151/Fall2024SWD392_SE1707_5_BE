using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Dashboard;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashBoardService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int month, int year)
        {

            var monthlyQuantities = new List<GettMonthQuantity>();


            var importByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleMonthAndYearAsync("In", month, year);
            var exportByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleMonthAndYearAsync("Out", month, year);
            var checkRequest = await _unitOfWork.CheckRequestDetails.GetQuantityByMonthAndYearAsync(month, year);

            int importCount = importByMonth.Count;
            int exportCount = exportByMonth.Count;

            monthlyQuantities.Add(new GettMonthQuantity
            {
                Month = month,
                ImportRequestQuantity = importCount,
                ExportRequestQuantity = exportCount,
                overstock = checkRequest.totalPositive,
                insufficientStock = checkRequest.totalNegative
            });


            return monthlyQuantities;
        }
    }
}
