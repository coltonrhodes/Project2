using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChirpersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChirpersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chirpers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chirper.ToListAsync());
        }

        // GET: Chirpers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chirper = await _context.Chirper
                .SingleOrDefaultAsync(m => m.id == id);
            if (chirper == null)
            {
                return NotFound();
            }

            return View(chirper);
        }

        // GET: Chirpers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chirpers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,body,email,date_time")] Chirper chirper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chirper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chirper);
        }

        // GET: Chirpers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chirper = await _context.Chirper.SingleOrDefaultAsync(m => m.id == id);
            if (chirper == null)
            {
                return NotFound();
            }
            return View(chirper);
        }

        // POST: Chirpers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,body,email,date_time")] Chirper chirper)
        {
            if (id != chirper.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chirper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChirperExists(chirper.id))
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
            return View(chirper);
        }

        // GET: Chirpers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chirper = await _context.Chirper
                .SingleOrDefaultAsync(m => m.id == id);
            if (chirper == null)
            {
                return NotFound();
            }

            return View(chirper);
        }

        // POST: Chirpers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chirper = await _context.Chirper.SingleOrDefaultAsync(m => m.id == id);
            _context.Chirper.Remove(chirper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChirperExists(int id)
        {
            return _context.Chirper.Any(e => e.id == id);
        }
    }
}
