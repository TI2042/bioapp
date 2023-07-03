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
    public class PatientGroupsController : Controller
    {
        private readonly BioContext _context;

        public PatientGroupsController(BioContext context)
        {
            _context = context;
        }

        // GET: PatientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientGroup.ToListAsync());
        }

        // GET: PatientGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientGroup = await _context.PatientGroup
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientGroup == null)
            {
                return NotFound();
            }

            return View(patientGroup);
        }

        // GET: PatientGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] PatientGroup patientGroup)
        {
            if (ModelState.IsValid)
            {
                patientGroup.id = Guid.NewGuid();
                _context.Add(patientGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientGroup);
        }

        // GET: PatientGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientGroup = await _context.PatientGroup.FindAsync(id);
            if (patientGroup == null)
            {
                return NotFound();
            }
            return View(patientGroup);
        }

        // POST: PatientGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name")] PatientGroup patientGroup)
        {
            if (id != patientGroup.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientGroupExists(patientGroup.id))
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
            return View(patientGroup);
        }

        // GET: PatientGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientGroup = await _context.PatientGroup
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientGroup == null)
            {
                return NotFound();
            }

            return View(patientGroup);
        }

        // POST: PatientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var patientGroup = await _context.PatientGroup.FindAsync(id);
            _context.PatientGroup.Remove(patientGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientGroupExists(Guid id)
        {
            return _context.PatientGroup.Any(e => e.id == id);
        }
    }
}
