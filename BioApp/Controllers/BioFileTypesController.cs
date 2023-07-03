using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioApp.Data;
using BioApp.Models;

namespace BioApp.Controllers
{
    public class BioFileTypesController : Controller
    {
        private readonly BioContext _context;

        public BioFileTypesController(BioContext context)
        {
            _context = context;
        }

        // GET: BioFileTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileTypes.ToListAsync());
        }

        // GET: BioFileTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (bioFileType == null)
            {
                return NotFound();
            }

            return View(bioFileType);
        }

        // GET: BioFileTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BioFileTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] BioFileType bioFileType)
        {
            if (ModelState.IsValid)
            {
                bioFileType.id = Guid.NewGuid();
                _context.Add(bioFileType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bioFileType);
        }

        // GET: BioFileTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFileType = await _context.FileTypes.FindAsync(id);
            if (bioFileType == null)
            {
                return NotFound();
            }
            return View(bioFileType);
        }

        // POST: BioFileTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name")] BioFileType bioFileType)
        {
            if (id != bioFileType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioFileType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioFileTypeExists(bioFileType.id))
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
            return View(bioFileType);
        }

        // GET: BioFileTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (bioFileType == null)
            {
                return NotFound();
            }

            return View(bioFileType);
        }

        // POST: BioFileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bioFileType = await _context.FileTypes.FindAsync(id);
            _context.FileTypes.Remove(bioFileType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioFileTypeExists(Guid id)
        {
            return _context.FileTypes.Any(e => e.id == id);
        }
    }
}
