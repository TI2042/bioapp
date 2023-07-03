using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioApp.Data;
using BioApp.Models;
using Newtonsoft.Json;

namespace BioApp.Controllers
{
    public class MKBClassifiersController : Controller
    {
        private readonly BioContext _context;

        public MKBClassifiersController(BioContext context)
        {
            _context = context;
        }

        // GET: MKBClassifiers
        public async Task<IActionResult> Index(Guid PatientId)
        {                       
            var patient = _context.Patients.FirstOrDefault(x => x.id == PatientId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == PatientId);
            List<MKBClassifier> items = _context.MKBClassifier.Where(x => x.Patients.Contains(patient)).ToList();
            return View(await _context.MKBClassifier.Where(x => x.Patients.Contains(patient)).ToListAsync());
        }

        // GET: MKBClassifiers/Details/5
        public async Task<IActionResult> Details(int? id, Guid patientId)
        {
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == patientId);
            if (id == null)
            {
                return NotFound();
            }

            var mKBClassifier = await _context.MKBClassifier
                .FirstOrDefaultAsync(m => m.id == id);
            if (mKBClassifier == null)
            {
                return NotFound();
            }

            return View(mKBClassifier);
        }
        [HttpGet]
        public IActionResult Select(Guid patientId)
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            var classifiers = _context.MKBClassifier.ToList();
            List<CommonAnalysis> commonAnalyses = _context.CommonAnalysis.Where(x => x.PatientId == patientId).ToList();
            List<AnalysisMarkerData> analysisResults = new List<AnalysisMarkerData>();
            
            //Select all results
            foreach (CommonAnalysis commonAnalysis in commonAnalyses)
            {
                analysisResults.AddRange(_context.AnalysisMarkerData.Where(x => x.CommonAnalysisId == commonAnalysis.id && x.boolValue == true).Include(x => x.analysisMarker).OrderBy(x => x.analysisMarker.orderRank).ToList());
            }
            double risk = 1;
            //Пока изичная формула Бернулли 
            foreach(AnalysisMarkerData result in analysisResults)
            {
                risk *= 1 - result.analysisMarker.probability;
            }
            risk = 1 - risk;


            foreach (var classifer in classifiers)
            {
                TreeViewNode node = new TreeViewNode();
                node.id = classifer.id.ToString();
                node.parent = (classifer.parentId == null ? "#" : classifer.parentId.ToString());
                node.text = classifer.name + " " +classifer.code +" ( " + classifer.nodeCount + " )";
                nodes.Add(node);
            }
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            ViewData["Risk"] = risk;
            ViewData["Classifiers"] = classifiers;
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == patientId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Select(Guid patientId, string selectedItems)
        {
            List<TreeViewNode> items = JsonConvert.DeserializeObject<List<TreeViewNode>>(selectedItems);
            //List<MKBClassifier> classifiers = new List<MKBClassifier>();            
            Patient patient = _context.Patients.FirstOrDefault(x => x.id == patientId);          
            foreach (TreeViewNode item in items)
            {
                patient.MKBClassifiers.Add(_context.MKBClassifier.FirstOrDefault(x => x.id == Int32.Parse(item.id)));
            }
            _context.Update(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { PatientId = patientId });
        }

            // GET: MKBClassifiers/Create
            public IActionResult Create(Guid patientId)
        {

            return View();
        }

        // POST: MKBClassifiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,code,parentId,parentCode,nodeCount,additionalInfo")] MKBClassifier mKBClassifier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mKBClassifier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mKBClassifier);
        }

        // GET: MKBClassifiers/Edit/5
        public async Task<IActionResult> Edit(int? id, Guid patientId)
        {
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == patientId);
            if (id == null)
            {
                return NotFound();
            }

            var mKBClassifier = await _context.MKBClassifier.FindAsync(id);
            if (mKBClassifier == null)
            {
                return NotFound();
            }
            return View(mKBClassifier);
        }

        // POST: MKBClassifiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,code,parentId,parentCode,nodeCount,additionalInfo")] MKBClassifier mKBClassifier, Guid patientId)
        {
            if (id != mKBClassifier.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mKBClassifier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MKBClassifierExists(mKBClassifier.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { PatientId = patientId });
            }
            return View(mKBClassifier);
        }

        // GET: MKBClassifiers/Delete/5
        public async Task<IActionResult> Delete(int? id, Guid patientId)
        {
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == patientId);
            if (id == null)
            {
                return NotFound();
            }

            var mKBClassifier = await _context.MKBClassifier
                .FirstOrDefaultAsync(m => m.id == id);
            if (mKBClassifier == null)
            {
                return NotFound();
            }

            return View(mKBClassifier);
        }

        // POST: MKBClassifiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Guid patientId)
        {
            var mKBClassifier = await _context.MKBClassifier.FindAsync(id);
            Patient patient = _context.Patients.Include(x => x.MKBClassifiers).FirstOrDefault(x => x.id == patientId);
            patient.MKBClassifiers.Remove(mKBClassifier);
            _context.Update(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { PatientId = patientId });
        }

        private bool MKBClassifierExists(int id)
        {
            return _context.MKBClassifier.Any(e => e.id == id);
        }
    }
}
