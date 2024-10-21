using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Dashboard;
using WWMS.DAL.Entities;
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

        //public async Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync()
        //{

        //    // 1 -> 12 moth
        //    var monthlyQuantities = new List<GettMonthQuantity>();


        //    for (int month = 1; month <= 12; month++)
        //    {
        //        var importByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleAndMonthAsync("In",month);
        //        var exportByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleAndMonthAsync("Out", month);
        //        // must get lack of product and over producr
        //        var checkRequest = await _unitOfWork.CheckRequestDetails.GetQuantityByMonthAsync(month);
        //        int importCount = importByMonth.Count;
        //        int exportCount = exportByMonth.Count;

        //        monthlyQuantities.Add(new GettMonthQuantity
        //        {
        //            Month = month,
        //            ImportRequestQuantity = importCount,
        //            ExportRequestQuantity = exportCount,
        //            overstock = checkRequest.totalPositive,
        //            insufficientStock = checkRequest.totalNegative
        //        });
        //    }



        //    return monthlyQuantities;



        //}

        public async Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int month,int year)
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
