using HabbitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HabbitApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Habbits.ToListAsync());
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Habbit habbit)
        {
            _context.Habbits.Add(habbit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            //if (id != null)
            //{
            //    Habbit? habbit = await _context.Habbits.FirstOrDefaultAsync(p => p.Id == id);
            //    if (habbit != null)
            //    {
            //        _context.Habbits.Remove(habbit);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction("Index");
            //    }
            //}

            if (id != null)
            {
                Habbit habbit = new Habbit { Id = id.Value };
                _context.Entry(habbit).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // Edit

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Habbit? habbit = await _context.Habbits.FirstOrDefaultAsync(p => p.Id == id);
                if (habbit != null) return View(habbit);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Habbit habbit)
        {
            _context.Habbits.Update(habbit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}