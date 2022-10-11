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
            var pageCount = Math.Ceiling(_context.EmailOtps.Count()/pageResults) ;

            var data = await _context.EmailOtps
                .Skip((page-1)*(int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new DbInfoResponseDto { EmailOtps = data, CurrentPages = page, Pages =(int)pageCount };

            return Ok(response);
        }
        

        //Swagger Working Code
        //[HttpGet("{page}")]
        //public async Task<ActionResult<List<EmailOtp>>> GetDbInfo(int page)
        //{
        //    if (_context.EmailOtps == null)
        //        return NotFound();

        //    var pageResults = 3f;
        //    var pageCount = Math.Ceiling(_context.EmailOtps.Count()/pageResults) ;

        //    var data = await _context.EmailOtps
        //        .Skip((page-1)*(int)pageResults)
        //        .Take((int)pageResults)
        //        .ToListAsync();

        //    var response = new DbInfoResponseDto { EmailOtps = data, CurrentPages = page, Pages =(int)pageCount };

        //    return Ok(response);
        //}

        //[HttpGet("{page}")]
        //public JsonResult GetDbInfo(int page)
        //{
        //    var pageResults = 3f;
        //    var pageCount = Math.Ceiling(_context.EmailOtps.Count() / pageResults);

        //    var data = _context.EmailOtps
        //        .Skip((page - 1) * (int)pageResults)
        //        .Take((int)pageResults)
        //        .ToListAsync();
        //    var str = JsonConvert.SerializeObject(data);

        //    return JObject.Parse(str);
        //    //return Ok(response);
        //}
    }
}
