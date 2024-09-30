using AutoMapper;
using WWMS.BAL.Models.AdditionalImportRequests;
using WWMS.BAL.Models.ImportRequests;
using WWMS.BAL.Models.Users;
using WWMS.BAL.Models.Warehouses;
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

            #region Import
            CreateMap<ImportRequest, GetImportRequestRespone>()
                            .ForMember(c => c.Username, c => c.MapFrom(c => c.User.Username))
                            .ForMember(w => w.WineName, w => w.MapFrom(w => w.Wine.WineName));
            CreateMap<CreateImportRequest, ImportRequest>();

            CreateMap<UpdateImportRequest, ImportRequest>();
            #endregion

            #region Additional Import Request
            CreateMap<AdditionalImportRequest, GetAdditionalImportRequest>()
                            .ForMember(c => c.Usernames, c => c.MapFrom(c => c.User.Username))
                            .ForMember(w => w.RequesterNames, w => w.MapFrom(w => w.ImportRequest.RequesterName));

                    
            CreateMap<CreateAdditionalImportRequest, AdditionalImportRequest>();

            CreateMap<UpdateAdditionalImportRequest, AdditionalImportRequest>();
            #endregion




            #region Warehouse
            CreateMap<Warehouse, GetWarehouseResponse>();

            CreateMap<CreateUpdateWarehouseRequest, Warehouse>();
            #endregion
        }
    }
}
