using WWMS.BAL.Helpers;

namespace WWMS.BAL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
