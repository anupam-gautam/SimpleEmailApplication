using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleEmailApplication.Models;

namespace SimpleEmailApplication.Controllers
{
    public class testController : Controller
    {
        private readonly EmailOtpAuthContext _context;

        public testController(EmailOtpAuthContext context)
        {
            _context = context;
        }

        // GET: test
        public async Task<IActionResult> Index()
        {
              return View(await _context.EmailOtps.ToListAsync());
        }

        // GET: test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmailOtps == null)
            {
                return NotFound();
            }

            var emailOtp = await _context.EmailOtps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailOtp == null)
            {
                return NotFound();
            }

            return View(emailOtp);
        }

        // GET: test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Otp")] EmailOtp emailOtp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailOtp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailOtp);
        }

        // GET: test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmailOtps == null)
            {
                return NotFound();
            }

            var emailOtp = await _context.EmailOtps.FindAsync(id);
            if (emailOtp == null)
            {
                return NotFound();
            }
            return View(emailOtp);
        }

        // POST: test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Otp")] EmailOtp emailOtp)
        {
            if (id != emailOtp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailOtp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailOtpExists(emailOtp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emailOtp);
        }

        // GET: test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmailOtps == null)
            {
                return NotFound();
            }

            var emailOtp = await _context.EmailOtps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailOtp == null)
            {
                return NotFound();
            }

            return View(emailOtp);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmailOtps == null)
            {
                return Problem("Entity set 'EmailOtpAuthContext.EmailOtps'  is null.");
            }
            var emailOtp = await _context.EmailOtps.FindAsync(id);
            if (emailOtp != null)
            {
                _context.EmailOtps.Remove(emailOtp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailOtpExists(int id)
        {
          return _context.EmailOtps.Any(e => e.Id == id);
        }
    }
}
