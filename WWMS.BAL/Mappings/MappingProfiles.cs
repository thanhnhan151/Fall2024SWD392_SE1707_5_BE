using AutoMapper;
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

            #region WineCategory
            CreateMap<WineCategory, GetWineCategoryResponse>();

            CreateMap<CreateWineCategoryRequest, WineCategory>();
            #endregion
        }
    }
}
