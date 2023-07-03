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
    public class BioFilesController : Controller
    {
        private readonly BioContext _context;

        public BioFilesController(BioContext context)
        {
            _context = context;
        }

        // GET: BioFiles
        public async Task<IActionResult> Index(Guid? PatientId)
        {
            var bioContext = _context.Files.Include(b => b.fileType).Include(b => b.patient).Where(b => b.PatientId == PatientId);
            ViewData["PatientId"] = PatientId;
            return View(await bioContext.ToListAsync());
        }

        // GET: BioFiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFile = await _context.Files
                .Include(b => b.fileType)
                .Include(b => b.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (bioFile == null)
            {
                return NotFound();
            }

            return View(bioFile);
        }

        // GET: BioFiles/Create
        public IActionResult Create(Guid? PatientId)
        {
            ViewData["BioFileTypeId"] = new SelectList(_context.FileTypes, "id", "name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name");
            ViewData["Patient"] = PatientId;
            return View();
        }

        // POST: BioFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,path,createDate,BioFileTypeId,PatientId")] BioFile bioFile, Guid? PatientId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bioFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { PatientId = PatientId });
            }
            ViewData["BioFileTypeId"] = new SelectList(_context.FileTypes, "id", "name", bioFile.BioFileTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", bioFile.PatientId);
            ViewData["Patient"] = PatientId;
            return View(bioFile);
        }

        // GET: BioFiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFile = await _context.Files.FindAsync(id);
            if (bioFile == null)
            {
                return NotFound();
            }
            ViewData["BioFileTypeId"] = new SelectList(_context.FileTypes, "id", "name", bioFile.BioFileTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", bioFile.PatientId);
            return View(bioFile);
        }

        // POST: BioFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,path,createDate,BioFileTypeId,PatientId")] BioFile bioFile, Guid? PatientId)
        {
            if (id != bioFile.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioFileExists(bioFile.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),  new { PatientId = PatientId });
            }
            ViewData["BioFileTypeId"] = new SelectList(_context.FileTypes, "id", "name", bioFile.BioFileTypeId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "id", "name", bioFile.PatientId);
            return View(bioFile);
        }

        // GET: BioFiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioFile = await _context.Files
                .Include(b => b.fileType)
                .Include(b => b.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (bioFile == null)
            {
                return NotFound();
            }

            return View(bioFile);
        }

        // POST: BioFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bioFile = await _context.Files.FindAsync(id);
            _context.Files.Remove(bioFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { PatientId = bioFile.PatientId });
        }

        private bool BioFileExists(Guid id)
        {
            return _context.Files.Any(e => e.id == id);
        }
    }
}
