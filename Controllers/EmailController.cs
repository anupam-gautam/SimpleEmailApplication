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

        //private readonly EmailVerificationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly EmailOtpAuthContext _context;

        public EmailController(IEmailService emailService, EmailOtpAuthContext context, IOtpService otpService)
        {
            _emailService = emailService;
            _context = context;
            _otpService = otpService;
        }

        [Route("SendEmail")]
        [HttpPost]
        public IActionResult SendEmailInfo([FromBody] EmailDto model)
        {
            try
            {
                string otp = _otpService.GenerateOtp();
                _context.EmailOtps.Add(new EmailOtp
                {
                    Id = 0,
                    Email = model.To,
                    Otp = otp,
                });
                _context.SaveChanges();

                //EMAIL Service
                _emailService.SendEmail(model, otp);
                //return Ok();
                return Ok(new
                {
                    StatusCode = StatusCode(200),
                    Model = model,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("DbCheck")]
        //to validate input in database records
        public IActionResult DatabaseValidate(EmailDto model)
        {
            var dbItem = _context.EmailOtps;
            var test = dbItem.ToList().Where(u => u.Email == model.To && u.Otp == model.OTP).FirstOrDefault();
            if (test != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}