using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbobaApplication.Data;
using AbobaApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace AbobaApplication.Controllers
{
    public class AbobasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbobasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Abobas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aboba.ToListAsync());
        }
        
        // GET: Abobas/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }


        // PoST: Abobas/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Aboba.Where(filt => filt.AbobaQuestion.Contains(SearchPhrase)).ToListAsync()); 
        }

        // GET: Abobas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboba = await _context.Aboba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboba == null)
            {
                return NotFound();
            }

            return View(aboba);
        }

        [Authorize]

        // GET: Abobas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abobas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AbobaQuestion,AbobbaAnswer")] Aboba aboba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboba);
        }

        [Authorize]
        // GET: Abobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboba = await _context.Aboba.FindAsync(id);
            if (aboba == null)
            {
                return NotFound();
            }
            return View(aboba);
        }

        // POST: Abobas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AbobaQuestion,AbobbaAnswer")] Aboba aboba)
        {
            if (id != aboba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbobaExists(aboba.Id))
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
            return View(aboba);
        }

        [Authorize]
        // GET: Abobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboba = await _context.Aboba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboba == null)
            {
                return NotFound();
            }

            return View(aboba);
        }


        // POST: Abobas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboba = await _context.Aboba.FindAsync(id);
            if (aboba != null)
            {
                _context.Aboba.Remove(aboba);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbobaExists(int id)
        {
            return _context.Aboba.Any(e => e.Id == id);
        }
    }
}
