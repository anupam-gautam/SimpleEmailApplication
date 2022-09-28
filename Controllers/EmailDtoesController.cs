using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleEmailApplication.Data;
using SimpleEmailApplication.Models;

namespace SimpleEmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailDtoesController : ControllerBase
    {
        private readonly EmailVerificationDbContext _context;

        public EmailDtoesController(EmailVerificationDbContext context)
        {
            _context = context;
        }

        //// GET: api/EmailDtoes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EmailDto>>> GetEmailDtos()
        //{
        //    return await _context.EmailDtos.ToListAsync();
        //}

        //// GET: api/EmailDtoes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EmailDto>> GetEmailDto(int id)
        //{
        //    var emailDto = await _context.EmailDtos.FindAsync(id);

        //    if (emailDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return emailDto;
        //}

        //// PUT: api/EmailDtoes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmailDto(int id, EmailDto emailDto)
        //{
        //    if (id != emailDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(emailDto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmailDtoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/EmailDtoes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailDto>> PostEmailDto(EmailDto emailDto)
        {
            _context.EmailDtos.Add(emailDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailDto", new { id = emailDto.Id }, emailDto);
        }

        // DELETE: api/EmailDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailDto(int id)
        {
            var emailDto = await _context.EmailDtos.FindAsync(id);
            if (emailDto == null)
            {
                return NotFound();
            }

            _context.EmailDtos.Remove(emailDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailDtoExists(int id)
        {
            return _context.EmailDtos.Any(e => e.Id == id);
        }
    }
}
