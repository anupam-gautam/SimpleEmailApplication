using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbInfoController : ControllerBase
    {
        private readonly EmailOtpAuthContext _context;
        public DbInfoController(EmailOtpAuthContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDbInfo")]
        public async Task<ActionResult<List<EmailOtp>>> GetDbInfo(int page)
        {
            if (_context.EmailOtps == null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.EmailOtps.Count() / pageResults);

            var data = await _context.EmailOtps
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new DbInfoResponseDto { EmailOtps = data, CurrentPages = page, Pages = (int)pageCount };

            return Ok(response);
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
