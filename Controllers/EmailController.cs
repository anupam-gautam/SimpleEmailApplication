﻿using MailKit.Net.Smtp;
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

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            try
            {
                //Catch OTP
                string otp = _otpService.GenerateOtp();
                _context.EmailOtps.Add(new EmailOtp
                {
                    Id = request.Id,
                    Email = request.To,
                    Otp = otp,
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