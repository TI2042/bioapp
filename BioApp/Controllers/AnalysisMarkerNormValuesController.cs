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
    public class AnalysisMarkerNormValuesController : Controller
    {
        private readonly BioContext _context;

        public AnalysisMarkerNormValuesController(BioContext context)
        {
            _context = context;
        }

        // GET: AnalysisMarkerNormValues
        public async Task<IActionResult> Index()
        {
            var bioContext = _context.AnalysisMarkerNormValue.Include(a => a.AnalysisMarker).Include(a => a.PatientGroup);
            return View(await bioContext.ToListAsync());
        }

        // GET: AnalysisMarkerNormValues/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarkerNormValue = await _context.AnalysisMarkerNormValue
                .Include(a => a.AnalysisMarker)
                .Include(a => a.PatientGroup)
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysisMarkerNormValue == null)
            {
                return NotFound();
            }

            return View(analysisMarkerNormValue);
        }

        // GET: AnalysisMarkerNormValues/Create
        public IActionResult Create()
        {
            
            ViewData["AnalysisMarkerId"] = new SelectList(_context.AnalysisMarker, "id", "name");
            ViewData["PatientGroupId"] = new SelectList(_context.PatientGroup, "id", "name");
            return View();
        }

        // POST: AnalysisMarkerNormValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,AnalysisMarkerId,PatientGroupId,minValue,maxValue")] AnalysisMarkerNormValue analysisMarkerNormValue)
        {
            if (ModelState.IsValid)
            {
                analysisMarkerNormValue.id = Guid.NewGuid();
                _context.Add(analysisMarkerNormValue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnalysisMarkerId"] = new SelectList(_context.AnalysisMarker, "id", "name", analysisMarkerNormValue.AnalysisMarkerId);
            ViewData["PatientGroupId"] = new SelectList(_context.PatientGroup, "id", "name", analysisMarkerNormValue.PatientGroupId);
            return View(analysisMarkerNormValue);
        }

        // GET: AnalysisMarkerNormValues/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarkerNormValue = await _context.AnalysisMarkerNormValue.FindAsync(id);
            if (analysisMarkerNormValue == null)
            {
                return NotFound();
            }
            ViewData["AnalysisMarkerId"] = new SelectList(_context.AnalysisMarker, "id", "name", analysisMarkerNormValue.AnalysisMarkerId);
            ViewData["PatientGroupId"] = new SelectList(_context.PatientGroup, "id", "name", analysisMarkerNormValue.PatientGroupId);
            return View(analysisMarkerNormValue);
        }

        // POST: AnalysisMarkerNormValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,AnalysisMarkerId,PatientGroupId,minValue,maxValue")] AnalysisMarkerNormValue analysisMarkerNormValue)
        {
            if (id != analysisMarkerNormValue.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analysisMarkerNormValue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalysisMarkerNormValueExists(analysisMarkerNormValue.id))
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
            ViewData["AnalysisMarkerId"] = new SelectList(_context.AnalysisMarker, "id", "name", analysisMarkerNormValue.AnalysisMarkerId);
            ViewData["PatientGroupId"] = new SelectList(_context.PatientGroup, "id", "name", analysisMarkerNormValue.PatientGroupId);
            return View(analysisMarkerNormValue);
        }

        // GET: AnalysisMarkerNormValues/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysisMarkerNormValue = await _context.AnalysisMarkerNormValue
                .Include(a => a.AnalysisMarker)
                .Include(a => a.PatientGroup)
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysisMarkerNormValue == null)
            {
                return NotFound();
            }

            return View(analysisMarkerNormValue);
        }

        // POST: AnalysisMarkerNormValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var analysisMarkerNormValue = await _context.AnalysisMarkerNormValue.FindAsync(id);
            _context.AnalysisMarkerNormValue.Remove(analysisMarkerNormValue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalysisMarkerNormValueExists(Guid id)
        {
            return _context.AnalysisMarkerNormValue.Any(e => e.id == id);
        }
    }
}
