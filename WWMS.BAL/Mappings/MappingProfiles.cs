using AutoMapper;
using WWMS.BAL.Models.IORequestDetails;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.Rooms;
using WWMS.BAL.Models.Users;
using WWMS.BAL.Models.WineCategories;
using WWMS.BAL.Models.Wines;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Mappings
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region User
            CreateMap<User, GetUserResponse>();

            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserRequest, User>();
            #endregion

            #region Wine
            CreateMap<Wine, GetWineResponse>()
                .ForMember(w => w.CategoryName, w => w.MapFrom(w => w.WineCategory.CategoryName));

            CreateMap<CreateUpdateWineRequest, Wine>();
            #endregion

            #region Wine Category
            CreateMap<WineCategory, GetWineCategoryResponse>();

            CreateMap<WineCategory, GetWineCategoryWithList>();

            CreateMap<CreateWineCategoryRequest, WineCategory>();
            #endregion

            #region Room
            CreateMap<WineRoom, RoomItem>();

            CreateMap<Room, GetRoomResponse>();
            #endregion

            #region IORequest


            CreateMap<IORequest, GetIORequest>();

            CreateMap<CreateIORequest, IORequest>();


            CreateMap<CreateIORequestDetail, IORequestDetail>();
            CreateMap<UpdateIORequestDetail, IORequestDetail>();

            CreateMap<UpdateIORequest, IORequest>();
            #endregion
        }
    }
}
