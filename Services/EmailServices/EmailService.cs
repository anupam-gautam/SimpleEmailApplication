using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Xml;

namespace SimpleEmailApplication.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }



        public void SendEmail(EmailDto request, string otp)
        {
            var subjectXmlMessage = ""; 
           string path = @"F:\Office Work\SimpleEmailApplication\wwwroot\OtpMessageForBody.xml";

           using (FileStream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
           {
                XmlDocument template = new XmlDocument();
                template.Load(stream);
                var Content = template.InnerText;
                subjectXmlMessage = Content.Replace("{otp}", otp);

            }


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("SmtpConfiguration").GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = "OTP(One Time Password)";
            //email.Body = new TextPart(TextFormat.Html) { Text = subjectXmlMessage };
            email.Body = new TextPart(TextFormat.Html) { Text = subjectXmlMessage };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("SmtpConfiguration").GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("SmtpConfiguration").GetSection("EmailUsername").Value, _config.GetSection("SmtpConfiguration").GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}