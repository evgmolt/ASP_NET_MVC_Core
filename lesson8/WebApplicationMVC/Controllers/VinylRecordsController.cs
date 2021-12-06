using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class VinylRecordsController : Controller
    { 
        private readonly WebApplicationMVCContext _context;

        public VinylRecordsController(WebApplicationMVCContext context)
        {
            _context = context;
        }

        // GET: VinylRecords
        public async Task<IActionResult> Index(string searchString)
        {
            var records = from r in _context.VinylRecord select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                records = records.Where(s => s.Artist.Contains(searchString));
            }

            return View(await records.ToListAsync());
        }

        // GET: VinylRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinylRecord = await _context.VinylRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vinylRecord == null)
            {
                return NotFound();
            }

            return View(vinylRecord);
        }

        // GET: VinylRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VinylRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Artist,Album,Label,RealeaseDate")] VinylRecord vinylRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vinylRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vinylRecord);
        }

        // GET: VinylRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinylRecord = await _context.VinylRecord.FindAsync(id);
            if (vinylRecord == null)
            {
                return NotFound();
            }
            return View(vinylRecord);
        }

        // POST: VinylRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Artist,Album,Label,RealeaseDate")] VinylRecord vinylRecord)
        {
            if (id != vinylRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinylRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinylRecordExists(vinylRecord.Id))
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
            return View(vinylRecord);
        }

        // GET: VinylRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinylRecord = await _context.VinylRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vinylRecord == null)
            {
                return NotFound();
            }

            return View(vinylRecord);
        }

        // POST: VinylRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vinylRecord = await _context.VinylRecord.FindAsync(id);
            _context.VinylRecord.Remove(vinylRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinylRecordExists(int id)
        {
            return _context.VinylRecord.Any(e => e.Id == id);
        }
    }
}
