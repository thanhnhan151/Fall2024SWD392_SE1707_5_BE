using AutoMapper;
using WWMS.BAL.Models.ImportRequest;
using WWMS.BAL.Models.Users;
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
            #region Import
            CreateMap<ImportRequest, GetImportRequestRespone>();
            CreateMap<CreateImportRequest, ImportRequest>();
            #endregion
        }
    }
}
