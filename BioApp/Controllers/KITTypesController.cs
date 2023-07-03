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
    public class KITTypesController : Controller
    {
        private readonly BioContext _context;

        public KITTypesController(BioContext context)
        {
            _context = context;
        }

        // GET: KITTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.KITType.ToListAsync());
        }

        // GET: KITTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kITType = await _context.KITType
                .FirstOrDefaultAsync(m => m.id == id);
            if (kITType == null)
            {
                return NotFound();
            }

            return View(kITType);
        }

        // GET: KITTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KITTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description")] KITType kITType)
        {
            if (ModelState.IsValid)
            {
                kITType.id = Guid.NewGuid();
                _context.Add(kITType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kITType);
        }

        // GET: KITTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kITType = await _context.KITType.FindAsync(id);
            if (kITType == null)
            {
                return NotFound();
            }
            return View(kITType);
        }

        // POST: KITTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,description")] KITType kITType)
        {
            if (id != kITType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kITType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KITTypeExists(kITType.id))
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
            return View(kITType);
        }

        // GET: KITTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kITType = await _context.KITType
                .FirstOrDefaultAsync(m => m.id == id);
            if (kITType == null)
            {
                return NotFound();
            }

            return View(kITType);
        }

        // POST: KITTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var kITType = await _context.KITType.FindAsync(id);
            _context.KITType.Remove(kITType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KITTypeExists(Guid id)
        {
            return _context.KITType.Any(e => e.id == id);
        }
    }
}
