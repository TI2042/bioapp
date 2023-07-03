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
    public class AnalysisController : Controller
    {
        private readonly BioContext _context;

        public AnalysisController(BioContext context)
        {
            _context = context;
        }

        // GET: Analysis
        public async Task<IActionResult> Index()
        {
            var bioContext = _context.Analysis.Include(a => a.doctor).Include(a => a.melanomaType).Include(a => a.patient);
            
            return View(await bioContext.ToListAsync());
        }

        // GET: Analyses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysis = await _context.Analysis
                .Include(a => a.doctor)
                .Include(a => a.melanomaType)
                .Include(a => a.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysis == null)
            {
                return NotFound();
            }

            return View(analysis);
        }

        // GET: Analyses/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name");
            ViewData["MelanomaTypeId"] = new SelectList(_context.MelanomaTypes, "id", "name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name");
            return View();
        }

        // POST: Analyses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,number,DoctorId,bioSample,DateOfBiosampleCollecting,DateOfAnalysis,PatientId,AnalysisIsPerformedBy,preventiveCare,earlyMetastasis,lateMetastasis,melanomaConfirmedEarlyStage,MelanomaTypeId")] Analysis analysis)
        {
            if (ModelState.IsValid)
            {
                analysis.id = Guid.NewGuid();
                _context.Add(analysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", analysis.DoctorId);
            ViewData["MelanomaTypeId"] = new SelectList(_context.MelanomaTypes, "id", "name", analysis.MelanomaTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", analysis.PatientId);
            return View(analysis);
        }

        // GET: Analyses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysis = await _context.Analysis.FindAsync(id);
            if (analysis == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", analysis.DoctorId);
            ViewData["MelanomaTypeId"] = new SelectList(_context.MelanomaTypes, "id", "name", analysis.MelanomaTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", analysis.PatientId);
            return View(analysis);
        }

        // POST: Analyses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,number,DoctorId,bioSample,DateOfBiosampleCollecting,DateOfAnalysis,PatientId,AnalysisIsPerformedBy,preventiveCare,earlyMetastasis,lateMetastasis,melanomaConfirmedEarlyStage,MelanomaTypeId")] Analysis analysis)
        {
            if (id != analysis.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalysisExists(analysis.id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", analysis.DoctorId);
            ViewData["MelanomaTypeId"] = new SelectList(_context.MelanomaTypes, "id", "name", analysis.MelanomaTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", analysis.PatientId);
            return View(analysis);
        }

        // GET: Analyses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analysis = await _context.Analysis
                .Include(a => a.doctor)
                .Include(a => a.melanomaType)
                .Include(a => a.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (analysis == null)
            {
                return NotFound();
            }

            return View(analysis);
        }

        // POST: Analyses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var analysis = await _context.Analysis.FindAsync(id);
            _context.Analysis.Remove(analysis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalysisExists(Guid id)
        {
            return _context.Analysis.Any(e => e.id == id);
        }
    }
}
