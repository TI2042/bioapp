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
    public class MelanomaTypesController : Controller
    {
        private readonly BioContext _context;

        public MelanomaTypesController(BioContext context)
        {
            _context = context;
        }

        // GET: MelanomaTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MelanomaTypes.ToListAsync());
        }

        // GET: MelanomaTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melanomaType = await _context.MelanomaTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (melanomaType == null)
            {
                return NotFound();
            }

            return View(melanomaType);
        }

        // GET: MelanomaTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MelanomaTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,nameEng,nameLat,id")] MelanomaType melanomaType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melanomaType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(melanomaType);
        }

        // GET: MelanomaTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melanomaType = await _context.MelanomaTypes.FindAsync(id);
            if (melanomaType == null)
            {
                return NotFound();
            }
            return View(melanomaType);
        }

        // POST: MelanomaTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("name,nameEng,nameLat,id")] MelanomaType melanomaType)
        {
            if (id != melanomaType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melanomaType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MelanomaTypeExists(melanomaType.id))
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
            return View(melanomaType);
        }

        // GET: MelanomaTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melanomaType = await _context.MelanomaTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (melanomaType == null)
            {
                return NotFound();
            }

            return View(melanomaType);
        }

        // POST: MelanomaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var melanomaType = await _context.MelanomaTypes.FindAsync(id);
            _context.MelanomaTypes.Remove(melanomaType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MelanomaTypeExists(Guid id)
        {
            return _context.MelanomaTypes.Any(e => e.id == id);
        }
    }
}
