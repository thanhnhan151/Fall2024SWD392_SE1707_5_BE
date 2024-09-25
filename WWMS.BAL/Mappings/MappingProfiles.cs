using AutoMapper;
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
            #endregion
        }
    }
}
