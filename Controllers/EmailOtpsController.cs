using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleEmailApplication.Models;

namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailOtpsController : ControllerBase
    {
        private readonly EmailOtpAuthContext _context;

        public EmailOtpsController(EmailOtpAuthContext context)
        {
            _context = context;
        }

        // GET: api/EmailOtps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailOtp>>> GetEmailOtps()
        {
            return await _context.EmailOtps.ToListAsync();
        }

        // GET: api/EmailOtps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailOtp>> GetEmailOtp(int id)
        {
            var emailOtp = await _context.EmailOtps.FindAsync(id);

            if (emailOtp == null)
            {
                return NotFound();
            }

            return emailOtp;
        }

        // PUT: api/EmailOtps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailOtp(int id, EmailOtp emailOtp)
        {
            if (id != emailOtp.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailOtp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailOtpExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmailOtps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailOtp>> PostEmailOtp(EmailOtp emailOtp)
        {
            _context.EmailOtps.Add(emailOtp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailOtp", new { id = emailOtp.Id }, emailOtp);
        }

        // DELETE: api/EmailOtps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailOtp(int id)
        {
            var emailOtp = await _context.EmailOtps.FindAsync(id);
            if (emailOtp == null)
            {
                return NotFound();
            }

            _context.EmailOtps.Remove(emailOtp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailOtpExists(int id)
        {
            return _context.EmailOtps.Any(e => e.Id == id);
        }
    }
}
