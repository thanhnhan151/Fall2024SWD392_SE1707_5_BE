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

        public async Task CreateImportRequestAnync([FromBody] CreateImportRequest Import)
        {
                var wine = await _unitOfWork.Wines.GetEntityByIdAsync(Import.WineId);

                if (wine == null)
                {
                    throw new Exception("Rượu không tồn tại."); 
                 }
            var import = _mapper.Map<ImportRequest>(Import);
                import.RequestCode = GenerateRequestCode();
                import.ImportDate = _base.CreatedDate;
                import.Status = "In Progress";
                import.DeliveryStatus = "In Progress";
                import.TotalValue = wine.Price * import.TotalQuantity;
                await _unitOfWork.Imports.AddEntityAsync(import);
                await _unitOfWork.CompleteAsync();

        }
        private string GenerateRequestCode()
        {
            // generate dependent : IMP-yyMM (chỉ lấy năm và tháng)
            string datePart = DateTime.Now.ToString("yyMM"); //  (2 chữ số cho năm, 2 chữ số cho tháng)
            return $"IMP-{datePart}"; // Ví dụ: IMP-2309
        }

        public async Task UpdateImportRequestAsync(UpdateImportRequest Import)
        {
             _unitOfWork.Imports.UpdateEntity(_mapper.Map<ImportRequest>(Import));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableImportRequestAsync(long id)
        {
            await _unitOfWork.Imports.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }


    }
}
