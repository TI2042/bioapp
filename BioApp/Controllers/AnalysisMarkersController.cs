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
    public class AnalysisMarkersController : Controller
    {
        private readonly BioContext _context;

        public AnalysisMarkersController(BioContext context)
        {
            _context = context;
        }

        // GET: AnalysisMarkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnalysisMarker.ToListAsync());
        }

        // GET: AnalysisMarkers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarker = await _context.AnalysisMarker
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysisMarker == null)
            {
                return NotFound();
            }

            return View(analysisMarker);
        }

        // GET: AnalysisMarkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnalysisMarkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,nameEn,measure,measureEn")] AnalysisMarker analysisMarker)
        {
            if (ModelState.IsValid)
            {
                analysisMarker.id = Guid.NewGuid();
                _context.Add(analysisMarker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analysisMarker);
        }

        // GET: AnalysisMarkers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarker = await _context.AnalysisMarker.FindAsync(id);
            if (analysisMarker == null)
            {
                return NotFound();
            }
            return View(analysisMarker);
        }

        // POST: AnalysisMarkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,nameEn,measure,measureEn")] AnalysisMarker analysisMarker)
        {
            if (id != analysisMarker.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analysisMarker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalysisMarkerExists(analysisMarker.id))
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
            return View(analysisMarker);
        }

        // GET: AnalysisMarkers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarker = await _context.AnalysisMarker
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysisMarker == null)
            {
                return NotFound();
            }

            return View(analysisMarker);
        }

        // POST: AnalysisMarkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var analysisMarker = await _context.AnalysisMarker.FindAsync(id);
            _context.AnalysisMarker.Remove(analysisMarker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalysisMarkerExists(Guid id)
        {
            return _context.AnalysisMarker.Any(e => e.id == id);
        }
    }
}
