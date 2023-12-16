using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioApp.Data;
using BioApp.Models;
using System.Text;
using System.Diagnostics;

namespace BioApp.Controllers
{
    public class PatientVisitController : Controller
    {
        private readonly BioContext _context;

        private Guid _patientId;
        public PatientVisitController(BioContext context)
        {
            _context = context;
        }

        // GET: PatientVisit
        public async Task<IActionResult> Index(Guid PatientId)
        {

            _patientId = PatientId;
            var patient = _context.Patients.FirstOrDefault(x => x.id == _patientId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == _patientId);
            List<PatientVisits> items = _context.PatientVisits.Where(x => x.Patients.Contains(patient)).ToList();
            Debug.WriteLine(PatientId);
            return View(await _context.PatientVisits.Where(x => x.patientID == _patientId).ToListAsync());


        }

        // GET: PatientVisit/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientVisits = await _context.PatientVisits
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientVisits == null)
            {
                return NotFound();
            }

            return View(patientVisits);
        }

        // GET: PatientVisit/Create
        
        public async Task<IActionResult> Create(Guid PatientId)
        {
            var patientVisits =   _context.PatientVisits.FirstOrDefault(x => x.id == PatientId);
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == PatientId);
            Debug.WriteLine("create get");
            Debug.WriteLine(ViewData["PatientId"]);
            Debug.WriteLine("pat id");
            Debug.WriteLine(patientVisits);
            Debug.WriteLine(patientVisits.patientID);
            Debug.WriteLine(PatientId);
            //patientVisits.patientID = PatientId.ToString();
            //_context.Update(patientVisits);
            //await _context.SaveChangesAsync();
            return View(patientVisits);
        }

        // POST: PatientVisit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,passportNumber,seriaPassport,numberPassport,issuedByPassport,datePassport,kodPassport,IdNumber,SNILS,PlaceOfBirth,PlaceOfResidence,Age,INN,OMSNumber,name,birthDate,gender,registrationDate,previousMelanoma," +
            "previousMelanomaInFamily,nevusType,PresenceOfFreckles,ObligateFormsOfPrecancer,HormonalChanges,burns,immuneSystemDiseases,ageGroup,skinType,eyeType,hairType,hormonalChangesNew,geneticAbnormalitiesInChromosomes,melanoma,compoundMelonoma,parents,simba," +
            "relatives,numberOfMoles,nevus,birthmarks,uf,immuneSystem,XerodermaPigmentosum,patientID")] PatientVisits patientVisits, Guid PatientId)
        {
            ViewData["PatientId"] = _context.Patients.FirstOrDefault(x => x.id == PatientId);
            Debug.WriteLine(ViewData.Values);
            Debug.WriteLine(patientVisits);
            Debug.WriteLine(PatientId);

            if (ModelState.IsValid)
            {
                patientVisits.id = new Guid();
                //patientVisits.passportNumber =_patientId.passportNumber;
                //patientVisits.seriaPassport = _patientId.seriaPassport;
                //patientVisits.numberPassport = _patientId.numberPassport;
                //patientVisits.issuedByPassport = _patientId.issuedByPassport;
                //patientVisits.datePassport = _patientId.datePassport;
                //patientVisits.kodPassport = _patientId.kodPassport;
                //patientVisits.SNILS = _patientId.SNILS;
                //patientVisits.PlaceOfBirth = _patientId.PlaceOfBirth;
                //patientVisits.PlaceOfResidence = _patientId.PlaceOfResidence;
                //patientVisits.Age = _patientId.Age;
                //patientVisits.INN = _patientId.INN;
                //patientVisits.name = _patientId.name;
                //patientVisits.birthDate = _patientId.birthDate;
                //patientVisits.gender = _patientId.gender;
                //patientVisits.registrationDate = _patientId.registrationDate;
                //patientVisits.previousMelanoma = _patientId.previousMelanoma;
                //patientVisits.previousMelanomaInFamily = _patientId.previousMelanomaInFamily;
                //patientVisits.nevusType = _patientId.nevusType;
                //patientVisits.PresenceOfFreckles = _patientId.PresenceOfFreckles;
                //patientVisits.ObligateFormsOfPrecancer = _patientId.ObligateFormsOfPrecancer;
                //patientVisits.HormonalChanges = _patientId.HormonalChanges;
                //patientVisits.burns = _patientId.burns;
                //patientVisits.immuneSystemDiseases = _patientId.immuneSystemDiseases;
                //patientVisits.ageGroup = _patientId.ageGroup;
                //patientVisits.skinType = _patientId.skinType;
                //patientVisits.eyeType = _patientId.eyeType;
                //patientVisits.hairType = _patientId.hairType;
                //patientVisits.hormonalChangesNew = _patientId.hormonalChangesNew;
                //patientVisits.geneticAbnormalitiesInChromosomes = _patientId.geneticAbnormalitiesInChromosomes;
                //patientVisits.melanoma = _patientId.melanoma;
                //patientVisits.compoundMelonoma = _patientId.compoundMelonoma;
                //patientVisits.parents = _patientId.parents;
                //patientVisits.simba = _patientId.simba;
                //patientVisits.relatives = _patientId.relatives;
                //patientVisits.numberOfMoles = _patientId.numberOfMoles;
                //patientVisits.nevus = _patientId.nevus;
                //patientVisits.birthmarks = _patientId.birthmarks;
                //patientVisits.uf = _patientId.uf;
                //patientVisits.immuneSystem = _patientId.immuneSystem;
                //patientVisits.XerodermaPigmentosum = _patientId.XerodermaPigmentosum;
                //patientVisits.patientID = PatientId.ToString();

                _context.Add(patientVisits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { PatientId = PatientId });
            }
            return View(patientVisits);
        }

        // GET: PatientVisit/Edit/5
        public async Task<IActionResult> Edit(Guid? id, Guid PatientId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientVisits = await _context.PatientVisits.FindAsync(id);
            if (patientVisits == null)
            {
                return NotFound();
            }
            patientVisits.patientID = PatientId;
            Debug.WriteLine("------------");
            Debug.WriteLine(PatientId);
            Debug.WriteLine(patientVisits.patientID);
            Debug.WriteLine("------------");
            _context.Update(patientVisits);
            await _context.SaveChangesAsync();
            return View(patientVisits);
        }

        // POST: PatientVisit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,passportNumber,seriaPassport,numberPassport,issuedByPassport,datePassport,kodPassport,IdNumber,SNILS,PlaceOfBirth,PlaceOfResidence,Age,INN,OMSNumber,name,birthDate,gender,registrationDate," +
            "previousMelanoma,previousMelanomaInFamily,nevusType,PresenceOfFreckles,ObligateFormsOfPrecancer,HormonalChanges,burns,immuneSystemDiseases,ageGroup,skinType,eyeType,hairType,hormonalChangesNew,geneticAbnormalitiesInChromosomes,melanoma,compoundMelonoma," +
            "parents,simba,relatives,numberOfMoles,nevus,birthmarks,uf,immuneSystem,XerodermaPigmentosum,patientID")] PatientVisits patientVisits,Guid PatientId)
        {
            if (id != patientVisits.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Debug.WriteLine("------------до апдейта");
                    Debug.WriteLine(patientVisits.patientID);
                    Debug.WriteLine("------------");
                    _context.Update(patientVisits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientVisitsExists(patientVisits.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { PatientId = PatientId });
            }
            return View(patientVisits);
        }

        // GET: PatientVisit/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientVisits = await _context.PatientVisits
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientVisits == null)
            {
                return NotFound();
            }

            return View(patientVisits);
        }

        // POST: PatientVisit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            var patientVisits = await _context.PatientVisits.FindAsync(id);
            var idBack = patientVisits.patientID;
            _context.PatientVisits.Remove(patientVisits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new { PatientId = idBack });
        }

        private bool PatientVisitsExists(Guid id)
        {
            return _context.PatientVisits.Any(e => e.id == id);
        }
    }
}
