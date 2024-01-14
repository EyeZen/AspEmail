using EmailApp.DTOs;

namespace EmailApp.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailBo emailRequest); 
    }
}
