using Microsoft.AspNetCore.Http;
using WWMS.BAL.Models.VnPays;

namespace WWMS.BAL.Interfaces
{
    public interface IVnPayService
    {
        public string CreateUrl(CreatePaymentRequest request);
        public Task<string> CreateUrl(int id);
        Task<VnPayResponse> ExecutePayment(IQueryCollection collections);
    }
}
