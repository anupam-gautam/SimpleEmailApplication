using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbSearchController : ControllerBase
    {
        private readonly EmailOtpAuthContext _context;
        public DbSearchController(EmailOtpAuthContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("DatabaseSearch")]
        public IActionResult DatabaseSearch(EmailDto model)
        {
            
            var dbItem = _context.EmailOtps;
            var test = dbItem.Where(u => u.Email == model.To).ToList();
            var count = test.Count();   
            if (test != null)
            {
                return Ok(test);
              
                
            }
            return BadRequest();

            
        }
    }
}
