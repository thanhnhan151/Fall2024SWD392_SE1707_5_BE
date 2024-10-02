using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.AdditionalImportRequests;
using WWMS.DAL.Base;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class AdditionalImportRequestService : IAdditionalImportRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BaseEntity _base;

        public AdditionalImportRequestService(IUnitOfWork unitOfWork, IMapper mapper, BaseEntity baseEntity)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _base = baseEntity;
        }
        public async Task<List<GetAdditionalImportRequest>> GetAdditionalImportRequestAsync() => _mapper.Map<List<GetAdditionalImportRequest>>(await _unitOfWork.AdditionalImports.GetAllEntitiesAsync());

        public async Task<GetAdditionalImportRequest> GetAdditionalImportRequestIdAsync(long Import_id) => _mapper.Map<GetAdditionalImportRequest>(await _unitOfWork.AdditionalImports.GetEntityByIdAsync(Import_id));
        public async Task CreateAdditionalImportRequestAnync([FromBody] CreateAdditionalImportRequest Import)
        {

            var import = _mapper.Map<AdditionalImportRequest>(Import);
            import.RequestCode = GenerateRequestCode();
            import.TotalValue = Import.TotalValue; /// cần sữa lại 
            import.ImportDate = _base.CreatedDate;
            import.Status = "In Progress";

            await _unitOfWork.AdditionalImports.AddEntityAsync(import);
            await _unitOfWork.CompleteAsync();
        }



        private static string GenerateRequestCode()
        {
            string datePart = DateTime.Now.ToString("yyMM"); 
            Random random = new Random();
            int randomDigits = random.Next(1000, 9999); 

            return $"ADR-{datePart}{randomDigits}"; // Ví dụ: IMP-23091234
        }

        public async Task UpdateAdditionalImportRequestAsync(UpdateAdditionalImportRequest Import)
        {
            _unitOfWork.AdditionalImports.UpdateEntity(_mapper.Map<AdditionalImportRequest>(Import));

            await _unitOfWork.CompleteAsync();
        }

        public async  Task DisableAdditionalImportRequestAsync(long id)
        {
            await _unitOfWork.AdditionalImports.UpdateStateAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateStatusAdditionalImportRequestAsync(long id)
        {
            var exitAdd = await _unitOfWork.AdditionalImports.UpdateStatusSuccessAsync(id);
            if (exitAdd.Status == "Complete") 
            {
                var exitimport = await _unitOfWork.Imports.UpdateStatusSuccessAsync(exitAdd.ImportRequestId);
                var exitWines = await _unitOfWork.Wines.GetEntityByIdAsync(exitimport.WineId) ?? throw new Exception($"Wine with {exitimport.WineId} id does not exist");
                if (exitimport.Status == "Complete")
                {
                    exitWines.AvailableStock = exitWines.AvailableStock + exitimport.TotalQuantity;
                    _unitOfWork.Wines.UpdateEntity(exitWines);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    throw new Exception("Import request already complete or not available");
                }
            }

        }
    }
}
