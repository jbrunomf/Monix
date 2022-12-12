using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monix.Data;
using Monix.Models;

namespace Monix
{
    public class PhoneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhoneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phone
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phones.Include(p => p.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Phone/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phone/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: Phone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,Number,Type")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                phone.Id = Guid.NewGuid();
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", phone.PersonId);
            return View(phone);
        }

        // GET: Phone/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", phone.PersonId);
            return View(phone);
        }

        // POST: Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PersonId,Number,Type")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
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
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", phone.PersonId);
            return View(phone);
        }

        // GET: Phone/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Phones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Phones'  is null.");
            }
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(Guid id)
        {
          return (_context.Phones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
