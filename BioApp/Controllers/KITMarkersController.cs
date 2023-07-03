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
    public class KITMarkersController : Controller
    {
        private readonly BioContext _context;

        public KITMarkersController(BioContext context)
        {
            _context = context;
        }

        // GET: KITMarkers
        public async Task<IActionResult> Index()
        {
            var bioContext = _context.KITMarker.Include(k => k.analysis).Include(k => k.type)
                .Include(k => k.analysis.patient).Include(k => k.analysis.doctor);
            return View(await bioContext.ToListAsync());
        }

        // GET: KITMarkers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kITMarker = await _context.KITMarker
                .Include(k => k.analysis)
                .Include(k => k.type)
                .FirstOrDefaultAsync(m => m.id == id);
            if (kITMarker == null)
            {
                return NotFound();
            }

            return View(kITMarker);
        }

        // GET: KITMarkers/Create
        public IActionResult Create()
        {
            ViewData["AnalysisId"] = new SelectList(_context.Analysis.Include(k => k.doctor).Include(k => k.patient), "id", "AnalisString");
            ViewData["TypeId"] = new SelectList(_context.KITType, "id", "name");
            return View();
        }

        // POST: KITMarkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,AnalysisId,TypeId,absent,heterozygosity,homozygosity,NA")] KITMarker kITMarker)
        {
            if (ModelState.IsValid)
            {
                kITMarker.id = Guid.NewGuid();
                _context.Add(kITMarker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnalysisId"] = new SelectList(_context.Analysis.Include(k => k.doctor).Include(k => k.patient), "id", "AnalisString", kITMarker.AnalysisId);
            ViewData["TypeId"] = new SelectList(_context.KITType, "id", "name", kITMarker.TypeId);
            return View(kITMarker);
        }

        // GET: KITMarkers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kITMarker = await _context.KITMarker.FindAsync(id);
            if (kITMarker == null)
            {
                return NotFound();
            }
            ViewData["AnalysisId"] = new SelectList(_context.Analysis.Include(k => k.doctor).Include(k => k.patient), "id", "AnalisString", kITMarker.AnalysisId);
            ViewData["TypeId"] = new SelectList(_context.KITType, "id", "name", kITMarker.TypeId);
            return View(kITMarker);
        }

        // POST: KITMarkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,description,AnalysisId,TypeId,absent,heterozygosity,homozygosity,NA")] KITMarker kITMarker)
        {
            if (id != kITMarker.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kITMarker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KITMarkerExists(kITMarker.id))
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
            ViewData["AnalysisId"] = new SelectList(_context.Analysis.Include(k => k.doctor).Include(k => k.patient), "id", "AnalisString", kITMarker.AnalysisId);
            ViewData["TypeId"] = new SelectList(_context.KITType, "id", "name", kITMarker.TypeId);
            return View(kITMarker);
        }

        // GET: KITMarkers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kITMarker = await _context.KITMarker
                .Include(k => k.analysis)
                .Include(k => k.type)
                .Include(k => k.analysis.doctor)
                .Include(k => k.analysis.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (kITMarker == null)
            {
                return NotFound();
            }

            return View(kITMarker);
        }

        // POST: KITMarkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var kITMarker = await _context.KITMarker.FindAsync(id);
            _context.KITMarker.Remove(kITMarker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KITMarkerExists(Guid id)
        {
            return _context.KITMarker.Any(e => e.id == id);
        }
    }
}
