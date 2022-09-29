
namespace SimpleEmailApplication.Services.EmailServices
{
    public interface IEmailService
    {

        void SendEmail(EmailDto request, string otp);

    }
}