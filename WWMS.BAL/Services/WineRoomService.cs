using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.WineRoom;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class WineRoomService : IWineRoomService
    {
        #region init
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public WineRoomService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion
        public async Task<List<GetActiveWineRoomNameResponse>> getActiveWineRoomNameResponseAsync()
        => _mapper.Map<List<GetActiveWineRoomNameResponse>>(await _unitOfWork.WineRooms.GetAllActiveWineRoomAsync());

    }
}