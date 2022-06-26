using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitatyWebApp.Data;
using CitatyWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CitatyWebApp.Controllers
{
    public class CitatiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitatiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Citaties
        public async Task<IActionResult> Index()
        {
              return _context.Citaty != null ? 
                          View(await _context.Citaty.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Citaty'  is null.");
        }

        // GET: Citaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Citaty == null)
            {
                return NotFound();
            }

            var citaty = await _context.Citaty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaty == null)
            {
                return NotFound();
            }

            return View(citaty);
        }

        // GET: Citaties/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Citaties/SearchForm
        public IActionResult SearchForm()
        {
            return View();
        }
        [HttpPost]
        // POST: Citaties/SearchResults
        public async Task<IActionResult> SearchResults(String SearchCy)
        {
            return View("Index", await _context.Citaty.Where(c => c.Desc.Contains(SearchCy)).ToListAsync());
        }

        // POST: Citaties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desc")] Citaty citaty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citaty);
        }

        // GET: Citaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Citaty == null)
            {
                return NotFound();
            }

            var citaty = await _context.Citaty.FindAsync(id);
            if (citaty == null)
            {
                return NotFound();
            }
            return View(citaty);
        }

        // POST: Citaties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desc")] Citaty citaty)
        {
            if (id != citaty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitatyExists(citaty.Id))
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
            return View(citaty);
        }

        // GET: Citaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Citaty == null)
            {
                return NotFound();
            }

            var citaty = await _context.Citaty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaty == null)
            {
                return NotFound();
            }

            return View(citaty);
        }

        // POST: Citaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Citaty == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Citaty'  is null.");
            }
            var citaty = await _context.Citaty.FindAsync(id);
            if (citaty != null)
            {
                _context.Citaty.Remove(citaty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitatyExists(int id)
        {
          return (_context.Citaty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
