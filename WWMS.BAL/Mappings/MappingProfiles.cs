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
            CreateMap<User, GetUserResponse>()
                .ForMember(w => w.Role, w => w.MapFrom(w => w.Role.RoleName));
            #endregion

            #region Wine
            CreateMap<Wine, GetWineResponse>();

            CreateMap<Wine, GetWineDetailResponse>()
                .ForMember(w => w.Category, w => w.MapFrom(w => w.WineCategory.CategoryName))
                .ForMember(w => w.Country, w => w.MapFrom(w => w.Country.CountryName))
                .ForMember(w => w.Taste, w => w.MapFrom(w => w.Taste.TasteType))
                .ForMember(w => w.Class, w => w.MapFrom(w => w.Class.ClassType))
                .ForMember(w => w.Qualification, w => w.MapFrom(w => w.Qualification.QualificationType))
                .ForMember(w => w.Cork, w => w.MapFrom(w => w.Cork.CorkType))
                .ForMember(w => w.Brand, w => w.MapFrom(w => w.Brand.BrandName))
                .ForMember(w => w.BottleSize, w => w.MapFrom(w => w.BottleSize.BottleSizeType))
                .ForMember(w => w.AlcoholByVolume, w => w.MapFrom(w => w.AlcoholByVolume.AlcoholByVolumeType));

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


            CreateMap<CreateRoomRequest, Room>();


            CreateMap<UpdateRoomRequest, Room>();

            #endregion

            #region IORequest


            CreateMap<IORequest, GetIORequest>();
            CreateMap<IORequest, GetIORequest>();
            CreateMap<CreateIORequest, IORequest>();

            CreateMap<IORequestDetail, GetIORequestDetail>();
            CreateMap<CreateIORequestDetail, IORequestDetail>();
            CreateMap<UpdateIORequestDetail, IORequestDetail>();

            CreateMap<UpdateIORequest, IORequest>();
            #endregion
        }
    }
}
