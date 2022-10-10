using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbValidateController : ControllerBase
    {
        private readonly EmailOtpAuthContext _context;
        public DbValidateController(EmailOtpAuthContext context)
        {

            _context = context;

        }
        [HttpPost]
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
