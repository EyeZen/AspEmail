using EmailApp.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EmailApp.Services.EmailService
{
    public class EmailService : IDisposable, IEmailService
    {
        private bool _disposed = false;
        private SmtpClient _smtpClient;
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
            _smtpClient = new SmtpClient();

            Connect();
        }

        public void Connect()
        {
            if (!int.TryParse(_config["Smtp:Port"], out int smtpPort))
            {
                throw new Exception("Invalid Smtp-Port");
            }
            else
            {
                _smtpClient.Connect(
                    _config["Smtp:Host"],
                    smtpPort
                );
                _smtpClient.Authenticate(
                    _config["Smtp:Email"],
                    _config["Smtp:Password"]
                );
            }
        }

        public void SendEmail(EmailBo emailData)
        {
            var mailAddress = MailboxAddress.Parse("shanna.howe@ethereal.email");
            var email = new MimeMessage();
            email.From.Add(mailAddress);
            email.To.Add(mailAddress);
            email.Subject = emailData.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = emailData.Body
            };

            _smtpClient.Send(email);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Release managed resource ( managed by garbage collector )
                    _smtpClient.Disconnect(true);
                    _smtpClient.Dispose();
                }

                // Release unmanaged resource ( not managed by automatic garbage collection )
                _disposed = true;
            }
        }

        ~EmailService()
        {
            Dispose(false);
        }
    }
}
