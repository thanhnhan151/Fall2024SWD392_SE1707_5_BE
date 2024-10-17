using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequestDetails;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.ReportIORequest;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class ReportIORequestService : IReportIORequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportIORequestService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<GetReportIORequest?> GetReportIORequestByIdAsync(long id) => _mapper.Map<GetReportIORequest?>(await _unitOfWork.IIORequestsDetail.GetEntityByIdAsync(id));
  

        public async Task<List<GetReportIORequest>> GetReportIORequestListAsync()
        {
           
            var allReportIORequests = await _unitOfWork.IIORequestsDetail.GetAllEntitiesAsync();

            // Lọc danh sách để chỉ lấy những phần tử mà ReportCode không null hoặc empty
            var filteredReportIORequests = allReportIORequests
                .Where(reportIORequest => !string.IsNullOrEmpty(reportIORequest.ReportCode))
                .ToList();

            
            return _mapper.Map<List<GetReportIORequest>>(filteredReportIORequests);
        }

        public async Task UpdateReportIORequestAsync(UpdateReportIORequest updateReportIO,string file)
        {
            var currentReportIORequest = await _unitOfWork.IIORequestsDetail.GetEntityByIdAsync(updateReportIO.Id);

            if (currentReportIORequest == null) 
                throw new Exception("IORequest not found.");


            currentReportIORequest.ReportCode = !string.IsNullOrEmpty(updateReportIO.ReportCode) ? updateReportIO.ReportCode : currentReportIORequest.ReportCode;
            currentReportIORequest.ReportDescription = updateReportIO.ReportDescription ?? currentReportIORequest.ReportDescription;
            currentReportIORequest.ReporterAssigned = !string.IsNullOrEmpty(updateReportIO.ReporterAssigned) ? updateReportIO.ReporterAssigned : currentReportIORequest.ReporterAssigned;
            currentReportIORequest.DiscrepanciesFound = updateReportIO.DiscrepanciesFound ?? currentReportIORequest.DiscrepanciesFound;
            currentReportIORequest.DiscrepanciesFound = updateReportIO.DiscrepanciesFound != default ? updateReportIO.DiscrepanciesFound : currentReportIORequest.ActualQuantity;
            currentReportIORequest.ActualQuantity = updateReportIO.ActualQuantity != default ? updateReportIO.ActualQuantity : currentReportIORequest.ActualQuantity;
            currentReportIORequest.ReportFile = !string.IsNullOrEmpty(file) ? file : currentReportIORequest.ReportFile;
            _unitOfWork.IIORequestsDetail.UpdateEntity(currentReportIORequest);

            await _unitOfWork.IIORequestsDetail.CheckDoneAsync(updateReportIO.Id);
            await _unitOfWork.CompleteAsync();

        }


        public async Task DisableReportIORequestsAsync(long id)
        {
            await _unitOfWork.IIORequestsDetail.DisableAsync(id);
            await _unitOfWork.CompleteAsync();
        }


    }
}
