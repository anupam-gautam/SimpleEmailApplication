using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Security;
using MimeKit.Text;


namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailVerificationDbContext _context;
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService, EmailVerificationDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }

 

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            try {

                //OTP Generation
                var randomGenerator = new Random();
                int ranNumber = randomGenerator.Next(1, 10);
                string otp = ranNumber.ToString();

                //Update Database for Otp and the email
                _context.EmailDtos.Add(new EmailDto { 
                    Id = request.Id,
                    To = request.To,
                    Subject = null,
                    Body = null,
                    OTP = otp,
                });
                _context.SaveChanges();

                //EMAIL Service
                _emailService.SendEmail(request,otp);
                //return Ok();
                return Ok(new{
                    StatusCode = StatusCode(200)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
