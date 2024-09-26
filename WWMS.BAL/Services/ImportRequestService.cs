using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.ImportRequest;
using WWMS.BAL.Models.Users;
using WWMS.DAL.Base;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class ImportRequestService : IImportRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BaseEntity _base;

        public ImportRequestService(IUnitOfWork unitOfWork, IMapper mapper, BaseEntity baseEntity)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _base = baseEntity;
        }


        //get all
        public async Task<List<GetImportRequestRespone>> GetImportRequestAsync() => _mapper.Map<List<GetImportRequestRespone>>(await _unitOfWork.Imports.GetAllEntitiesAsync());

        public async Task<GetImportRequestRespone> GetImportRequestByIdAsync(long Import_id) => _mapper.Map<GetImportRequestRespone>(await _unitOfWork.Imports.GetEntityByIdAsync(Import_id));

        public async Task CreateImportRequestAnync([FromBody]CreateImportRequest Import)
        {
            var import = _mapper.Map<ImportRequest>(Import);
            import.Id = Import.Id;
            import.RequestCode = Import.RequestCode; // auto
            import.ImportDate = _base.CreatedDate;   
            import.Status = "In Progress";  ///  3 status // In Progress , Completed ,Cancelled
            import.TotalQuantity = import.TotalQuantity; // auto   ///TotalValue = TotalQuantity x  Wine (price)
            import.TotalValue = import.TotalValue;
            import.TransportDetails = import.TransportDetails; // thong tin van chuyen 
            import.Comments = import.Comments;  // ko can check null
            import.CustomsClearance = import.CustomsClearance;
            import.DeliveryStatus = import.DeliveryStatus;
            import.ExpectedArrival = import.ExpectedArrival;
            import.InsuranceProvider = import.InsuranceProvider;
            import.ShippingMethod = import.ShippingMethod;
            import.TaxDetails = import.TaxDetails;
            import.WineId = import.WineId;
            import.UserId = import.UserId;


            await _unitOfWork.Imports.AddEntityAsync(import);

            await _unitOfWork.CompleteAsync();

        }



    }
}
