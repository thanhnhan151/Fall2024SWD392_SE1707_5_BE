using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Dashboard;
using WWMS.BAL.Models.Wines;
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



        public async Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int year)
        {
            
            var monthlyQuantities = new List<GettMonthQuantity>();

            for (int month =1; month <= 12; month++)
            {
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

            }


            return monthlyQuantities;
        }


        public async Task<List<GetToltalWine>> GetQuantityWineListAsync()
        {
            var listWineQuantities = new List<GetToltalWine>();
            var listWine = await _unitOfWork.Wines.GetAllEntitiesAsync();
            var listWineRoom = await _unitOfWork.WineRooms.GetAllEntitiesAsync();
     
            foreach (var wine in listWine)
            {
                if (wine != null && wine.Status == "Active")
                {
                
                    var wineRoomsForWine = listWineRoom.Where(wr => wr.WineId == wine.Id).ToList();
                    var wines = _mapper.Map<GetWineDetailResponse>(await _unitOfWork.Wines.GetByIdWithIncludeAsync(wine.Id));
                  
                    if (wineRoomsForWine.Any())
                    {
            
                        var existingWine = listWineQuantities.FirstOrDefault(w => w.Id == wine.Id);
                    

              
                        if (existingWine == null)
                        {
                            existingWine = new GetToltalWine
                            {
                                Id = wine.Id,
                                WineName = wine.WineName,
                                CategoryName = wines.WineCategory.CategoryName,
                                ToltalQuantity = 0,
                                WineRooms = new List<WineItem>()
                            };

                            listWineQuantities.Add(existingWine);
                        }

                        foreach (var wineRoom in wineRoomsForWine)
                        {
                            var room = await _unitOfWork.Rooms.GetByIdNotTrack(wineRoom.RoomId);
                            var roomItem = new WineItem
                            {
                                RoomId = wineRoom.RoomId,
                                RoomName = room.RoomName,
                                CurrentQuantity = wineRoom.CurrentQuantity
                            };

                          
                            existingWine.WineRooms.Add(roomItem);

              
                            existingWine.ToltalQuantity += wineRoom.CurrentQuantity;
                        }
                    }
                }
            }

            return listWineQuantities;
        }



        public async Task<List<GettMonthQuantityIO>> GetQuantityPerMonthIOListAsync(int year)
        {

            var monthlyQuantities = new List<GettMonthQuantityIO>();

            for (int month = 1; month <= 12; month++)
            {
                var importByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleMonthAndYearAsync("In", month, year);
                var exportByMonth = await _unitOfWork.IIORequests.GetEntitiesByIOStyleMonthAndYearAsync("Out", month, year);
               

                int totalImportQuantity = 0;
                int totalExportQuantity = 0;

                foreach (var import in importByMonth)
                {
                    if(import.Status == "Done")
                    {
                        totalImportQuantity += import.IORequestDetails.Sum(detail => detail.Quantity);
                    }
                }

                foreach (var export in exportByMonth)
                {
                    if (export.Status == "Done")
                    {
                        totalExportQuantity += export.IORequestDetails.Sum(detail => detail.Quantity);
                    }
                }

                monthlyQuantities.Add(new GettMonthQuantityIO
                {
                    Month = month,
                    ImportMonthQuantity = totalImportQuantity,
                    ExportMonthQuantity = totalExportQuantity
                });

            }


            return monthlyQuantities;
        }
        // viết hàm de tinh tong ruou theo categoory
        public async Task<List<GetToltalWineCategory>> GetQuantityWineListCategoryAsync()
        {
 
            var total = await GetQuantityWineListAsync();

          
            var totalWineCategories = total
                .GroupBy(q => q.CategoryName)  
                .Select(g => new GetToltalWineCategory
                {
                    CategoryName = g.Key,  
                    ToltalQuantity = g.Sum(q => q.ToltalQuantity) 
                })
                .ToList();

            
            return totalWineCategories;
        }
    }
}
