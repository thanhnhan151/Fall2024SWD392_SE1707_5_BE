using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ICodeResetPassRepository : IGenericRepository<CodeResetPass>
    {
        //disable all previous
        Task DisablePrevious(string username);
        //check usable
        Task<bool> CheckUsable(string verifiedCode);
    }


}
