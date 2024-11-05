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
            //get all data
            var listWineQuantities = new List<GetToltalWine>();
            var listWine = await _unitOfWork.Wines.GetAllEntitiesAsync();
            var listWineRoom = await _unitOfWork.WineRooms.GetAllEntitiesAsync();
     
            foreach (var wine in listWine)
            {
                if (wine != null)
                {
                
                    var wineRoomsForWine = listWineRoom.Where(wr => wr.WineId == wine.Id).ToList();

                    if (wineRoomsForWine.Any())
                    {
            
                        var existingWine = listWineQuantities.FirstOrDefault(w => w.Id == wine.Id);

                        if (existingWine == null)
                        {
                            existingWine = new GetToltalWine
                            {
                                Id = wine.Id,
                                WineName = wine.WineName,
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



    }
}
