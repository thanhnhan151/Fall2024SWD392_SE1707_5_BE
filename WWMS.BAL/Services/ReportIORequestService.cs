using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequestDetails;
using WWMS.BAL.Models.IORequests;
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
        public async Task<GetIORequestDetail?> GetReportIORequestByIdAsync(long id) => _mapper.Map<GetIORequestDetail?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

        public Task UpdateReportIORequestAsync(UpdateIORequest updateIORequest)
        {
            throw new NotImplementedException();
        }

        public Task DisableReportIORequestsAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
