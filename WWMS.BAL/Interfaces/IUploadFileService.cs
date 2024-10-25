using Microsoft.AspNetCore.Http;

namespace WWMS.BAL.Interfaces
{
    public interface IUploadFileService
    {
        Task<string> UploadImage(IFormFile file);
    }
}
