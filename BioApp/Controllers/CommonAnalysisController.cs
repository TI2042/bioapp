using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioApp.Data;
using BioApp.Models;
using Microsoft.AspNetCore.Http;

namespace BioApp.Controllers
{
    public class CommonAnalysisController : Controller
    {
        private readonly BioContext _context;

        public CommonAnalysisController(BioContext context)
        {
            _context = context;
        }

        // GET: CommonAnalysis
        public async Task<IActionResult> Index(Guid PatientId)
        {
            var bioContext = _context.CommonAnalysis.Where(c => c.PatientId == PatientId).Include(c => c.doctor).Include(c => c.patient);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == PatientId);
            return View(await bioContext.ToListAsync());
        }

        // GET: CommonAnalysis/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonAnalysis = await _context.CommonAnalysis
                .Include(c => c.doctor)
                .Include(c => c.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (commonAnalysis == null)
            {
                return NotFound();
            }
            ViewData["Markers"] = _context.AnalysisMarkerData.Where(x => x.CommonAnalysisId == id).Include(x => x.analysisMarker).ToList();
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            return View(commonAnalysis);
        }

        // GET: CommonAnalysis/Create
        public IActionResult Create(Guid patientId, AnalysisType analysisType)
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name");
            ViewData["AnalysisType"] = analysisType.ToString();
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == patientId);
            ViewData["Markers"] = _context.AnalysisMarker.Where(x => x.analysisType == analysisType).OrderBy(x =>x.orderRank).ToList();          
            return View();
        }

        public void CreateMarkersData(CommonAnalysis commonAnalysis, IFormCollection data)
        {

            foreach (var item in data.ToList())
            {
                var marker = _context.AnalysisMarker.FirstOrDefault(x => x.id.ToString() == item.Key);
                if (marker == null)
                    continue;
                AnalysisMarkerData analysisMarkerData = new AnalysisMarkerData()
                {
                    id = Guid.NewGuid(),
                    analysisMarker = marker,
                    commonAnalysis = commonAnalysis,

                };
                switch (marker.dataType)  {
                    case DataType.Double:                        
                        double doubleValue = 0;
                        Double.TryParse(item.Value.ToString(), out doubleValue);
                        analysisMarkerData.doubleValue = doubleValue;
                        break;
                    case DataType.Bool:                                  
                        analysisMarkerData.boolValue = (item.Value.ToString() == "Выявлено");
                        if (item.Value.ToString() == "Не проводилось")
                            analysisMarkerData.boolValue = null;
                        break;
                    case DataType.String:                        
                        analysisMarkerData.stringValue = item.Value.ToString();
                        break;
                }
                _context.Add(analysisMarkerData);
            };
        }
                
            
        public void EditMarkersData(CommonAnalysis commonAnalysis, IFormCollection data)
        {

            foreach (var item in data.ToList())
            {
                double value = 0;
                Double.TryParse(item.Value.ToString(), out value);
                var markerData = _context.AnalysisMarkerData.Include(x => x.analysisMarker)
                             .FirstOrDefault(x => x.id.ToString() == item.Key);
                if (markerData == null)
                    continue;
                switch (markerData.analysisMarker.dataType)
                {
                    case DataType.Double:
                        double doubleValue = 0;
                        Double.TryParse(item.Value.ToString(), out doubleValue);
                        markerData.doubleValue = doubleValue;
                        break;
                    case DataType.Bool:
                        markerData.boolValue = (item.Value.ToString() == "Выявлено");
                        if (item.Value.ToString() == "Не проводилось")
                            markerData.boolValue = null;
                        break;
                    case DataType.String:
                        markerData.stringValue = item.Value.ToString();
                        break;
                }                
                _context.Update(markerData);
            }
        }

        // POST: CommonAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DoctorId,PatientId,DateOfBiosampleCollecting,DateOfAnalysis,AnalysisIsPerformedBy")] CommonAnalysis commonAnalysis,
                                                 IFormCollection data, AnalysisType analysisType)
        {

            if (ModelState.IsValid)
            {
                commonAnalysis.id = Guid.NewGuid();
                commonAnalysis.analysisType = analysisType;
                CreateMarkersData(commonAnalysis, data);
                _context.Add(commonAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { PatientId = commonAnalysis.PatientId });
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", commonAnalysis.DoctorId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            ViewData["Markers"] = _context.AnalysisMarker.Where(x => x.analysisType == commonAnalysis.analysisType).OrderBy(x => x.orderRank).ToList();
            return View(commonAnalysis);
        }

        // GET: CommonAnalysis/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var commonAnalysis = await _context.CommonAnalysis.FindAsync(id);
            if (commonAnalysis == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", commonAnalysis.DoctorId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            var makers = _context.AnalysisMarkerData.Where(x => x.CommonAnalysisId == id).Include(x => x.analysisMarker).OrderBy(x => x.analysisMarker.orderRank).ToList();
            ViewData["Markers"] = makers;// _context.AnalysisMarkerData.Where(x => x.CommonAnalysisId == id).Include(x => x.analysisMarker).OrderBy(x => x.analysisMarker.orderRank).ToList();
            //ViewData["Markers"] = _context.AnalysisMarker.Where(x => x.analysisType == AnalysisType.CommonBloodAnalysis).ToList();
            return View(commonAnalysis);
        }

        // POST: CommonAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,DoctorId,PatientId,DateOfBiosampleCollecting,DateOfAnalysis,AnalysisIsPerformedBy")] CommonAnalysis commonAnalysis,
            IFormCollection data, AnalysisType analysisType)
        {
            if (id != commonAnalysis.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    commonAnalysis.analysisType = analysisType;
                    EditMarkersData(commonAnalysis, data);
                    _context.Update(commonAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommonAnalysisExists(commonAnalysis.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { PatientId = commonAnalysis.PatientId });
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "id", "name", commonAnalysis.DoctorId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            ViewData["Markers"] = _context.AnalysisMarkerData.Where(x => x.CommonAnalysisId == id).Include(x => x.analysisMarker).OrderBy(x => x.analysisMarker.orderRank).ToList();
            return View(commonAnalysis);
        }

        // GET: CommonAnalysis/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var commonAnalysis = await _context.CommonAnalysis
                .Include(c => c.doctor)
                .Include(c => c.patient)
                .FirstOrDefaultAsync(m => m.id == id);
            if (commonAnalysis == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            return View(commonAnalysis);
        }

        // POST: CommonAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commonAnalysis = await _context.CommonAnalysis.FindAsync(id);
            _context.CommonAnalysis.Remove(commonAnalysis);
            await _context.SaveChangesAsync();
            //ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == commonAnalysis.PatientId);
            return RedirectToAction(nameof(Index), new { PatientId = commonAnalysis.PatientId });
        }

        private bool CommonAnalysisExists(Guid id)
        {
            return _context.CommonAnalysis.Any(e => e.id == id);
        }
    }
}
