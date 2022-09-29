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
        private readonly IOtpService _otpService;

        public EmailController(IEmailService emailService, EmailVerificationDbContext context, IOtpService otpService)
        {
            _emailService = emailService;
            _context = context;
            _otpService = otpService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            try
            {
                //Catch OTP
                string otp = _otpService.GenerateOtp();
                _context.EmailDtos.Add(new EmailDto
                {
                    Id = request.Id,
                    To = request.To,
                    Subject = null,
                    Body = null,
                    OTP = otp,
                });
                _context.SaveChanges();

                //EMAIL Service
                _emailService.SendEmail(request, otp);
                //return Ok();
                return Ok(new
                {
                    StatusCode = StatusCode(200),
                    Model = request,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}