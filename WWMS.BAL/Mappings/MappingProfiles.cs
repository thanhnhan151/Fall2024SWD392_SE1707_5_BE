using AutoMapper;
using WWMS.BAL.Models.ImportRequest.Request;
using WWMS.BAL.Models.ImportRequest.Responnse;
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
            CreateMap<ImportRequest,GetImportRequestRespone>();
            CreateMap<ImportRequestRes, ImportRequest>();
            #endregion
        }
    }
}
