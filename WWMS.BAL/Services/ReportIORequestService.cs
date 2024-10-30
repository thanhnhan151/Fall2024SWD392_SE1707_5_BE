using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests.IOrequestdetails;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.ReportIORequest;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetReportIORequest?> GetReportIORequestByIdAsync(long id)
        {
            var reportIORequest = await _unitOfWork.Reports.GetEntityByIdAsync(id);

      
            if (reportIORequest == null || string.IsNullOrWhiteSpace(reportIORequest.ReportCode))
            {
                return null; 
            }

            return _mapper.Map<GetReportIORequest?>(reportIORequest);
        }


        public async Task<List<GetReportIORequest>> GetReportIORequestListAsync()
        {
            var allReportIORequests = await _unitOfWork.Reports.GetAllEntitiesAsync();

            var filteredReportIORequests = allReportIORequests
                .Where(reportIORequest => !string.IsNullOrWhiteSpace(reportIORequest.ReportCode)) 
                .ToList();

            return _mapper.Map<List<GetReportIORequest>>(filteredReportIORequests);
        }
        // get All report By Io request id
        public async Task<List<GetReportIORequest>> GetReportByIORequestidAsync(long id)
        {
            var IORequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(id);

            if (IORequest == null)
            {
                throw new Exception("IORequest not found.");
            }


            var filteredIORequestDetails = IORequest.IORequestDetails
                .Where(detail => detail != null &&
                                !string.IsNullOrWhiteSpace(detail.ReportCode)).ToList();


            return _mapper.Map<List<GetReportIORequest>>(filteredIORequestDetails);
        }

        public async Task UpdateReportIORequestDetailsByIdAsync(CreateReport updateIORequest, long id)
        {

            var currentIORequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(id);

            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }

            
            if (currentIORequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to update.");
            }

           
            if (updateIORequest.IORequestDetails != null && updateIORequest.IORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.IORequestDetails)
                {
                
                    var existingDetail = currentIORequest.IORequestDetails
                        .FirstOrDefault(d => d.Id == newDetail.Id);

                    if (existingDetail != null)
                    {
               
                        existingDetail.ReportCode = string.IsNullOrEmpty(existingDetail.ReportCode) ? GenerateRandomCode(8) : existingDetail.ReportCode;
                        existingDetail.ReportDescription = string.IsNullOrEmpty(newDetail.ReportDescription) ? existingDetail.ReportDescription : newDetail.ReportDescription;
                        existingDetail.ReporterAssigned = string.IsNullOrEmpty(newDetail.ReporterAssigned) ? existingDetail.ReporterAssigned : newDetail.ReporterAssigned;
                        existingDetail.DiscrepanciesFound = newDetail.DiscrepanciesFound ?? existingDetail.DiscrepanciesFound;
                        existingDetail.ActualQuantity = newDetail.ActualQuantity != 0 ? newDetail.ActualQuantity : existingDetail.ActualQuantity;
                        existingDetail.ReportFile = string.IsNullOrEmpty(newDetail.ReportFile) ? existingDetail.ReportFile : newDetail.ReportFile;
                    }
                }
            }

 
            currentIORequest.UpdatedTime = DateTime.UtcNow;

            _unitOfWork.IIORequests.UpdateEntity(currentIORequest);
            await _unitOfWork.CompleteAsync();
        }

        public string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; 
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task DisableReportIORequestsAsync(long id, long detailId)
        {
        
            var parentRequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(id);
            if (parentRequest == null)
            {
                throw new Exception("IORequest not found.");
            }

          
            if (parentRequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to proceed.");
            }

           
            foreach (var current in parentRequest.IORequestDetails)
            {
                if (current.Id == detailId)
                {
                    current.ReportCode = " ";
                    current.ReportDescription =" ";
                    current.ReporterAssigned = " ";
                    current.DiscrepanciesFound = 0;
                    current.ActualQuantity = 0;
                    current.ReportFile = " ";
                    break;
                }
            }

            _unitOfWork.IIORequests.UpdateEntity(parentRequest);
            await _unitOfWork.CompleteAsync();
        }
    }
}
