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
    public class DoctorSpecializationsController : Controller
    {
        private readonly BioContext _context;

        public DoctorSpecializationsController(BioContext context)
        {
            _context = context;
        }

        // GET: DoctorSpecializations
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorSpecializations.ToListAsync());
        }

        // GET: DoctorSpecializations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialization = await _context.DoctorSpecializations
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctorSpecialization == null)
            {
                return NotFound();
            }

            return View(doctorSpecialization);
        }

        // GET: DoctorSpecializations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorSpecializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] DoctorSpecialization doctorSpecialization)
        {
            if (ModelState.IsValid)
            {
                doctorSpecialization.id = Guid.NewGuid();
                _context.Add(doctorSpecialization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorSpecialization);
        }

        // GET: DoctorSpecializations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialization = await _context.DoctorSpecializations.FindAsync(id);
            if (doctorSpecialization == null)
            {
                return NotFound();
            }
            return View(doctorSpecialization);
        }

        // POST: DoctorSpecializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name")] DoctorSpecialization doctorSpecialization)
        {
            if (id != doctorSpecialization.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorSpecialization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorSpecializationExists(doctorSpecialization.id))
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
            return View(doctorSpecialization);
        }

        // GET: DoctorSpecializations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialization = await _context.DoctorSpecializations
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctorSpecialization == null)
            {
                return NotFound();
            }

            return View(doctorSpecialization);
        }

        // POST: DoctorSpecializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doctorSpecialization = await _context.DoctorSpecializations.FindAsync(id);
            _context.DoctorSpecializations.Remove(doctorSpecialization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorSpecializationExists(Guid id)
        {
            return _context.DoctorSpecializations.Any(e => e.id == id);
        }
    }
}
