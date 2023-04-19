using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UniversityController : Controller
    {
        private readonly WebAppContext _context;

        public UniversityController(WebAppContext context)
        {
            _context = context;
        }

        // GET: University
        public async Task<IActionResult> Index()
        {
              return _context.University != null ? 
                          View(await _context.University.ToListAsync()) :
                          Problem("Entity set 'WebAppContext.University'  is null.");
        }

        // GET: University/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: University/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QSRank,Name,Description,Website,City,Image")] University university)
        {
            if (ModelState.IsValid)
            {
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: University/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: University/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QSRank,Name,Description,Website,City,Image")] University university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.Id))
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
            return View(university);
        }

        // GET: University/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: University/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'WebAppContext.University'  is null.");
            }
            var university = await _context.University.FindAsync(id);
            if (university != null)
            {
                _context.University.Remove(university);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int id)
        {
          return (_context.University?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
