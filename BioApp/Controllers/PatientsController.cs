using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BioApp.Data;
using BioApp.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace BioApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly BioContext _context;

        public PatientsController(BioContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }
        public async Task<IActionResult> Metrics()
        {

            int A = 0;
            int B = 0;
            int C = 0;
            int D = 0;
            ViewData["Asymmetry"] = A;
            ViewData["Border"] = B;
            ViewData["Color"] = C;
            ViewData["Diameter"] = D;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Metrics(List<IFormFile> files)
        {
            double A = 0;
            double B = 0;
            double C = 0;
            double D = 0;
            long size = files.Sum(f => f.Length);            
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("UploadedFiles",
                    formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(stream);
                        stream.Close();
                        var client = new HttpClient
                        {
                            BaseAddress = new("http://127.0.0.1:5000/getParameters")
                        };
                        FileStream outStream = System.IO.File.OpenRead(filePath);
                        using var request = new HttpRequestMessage(HttpMethod.Post, "getParameters");
                        using var content = new MultipartFormDataContent
                        {
                            { new StreamContent(outStream), "file", formFile.FileName }
                        };
                        request.Content = content;

                        HttpResponseMessage res = client.Send(request);
                        res.EnsureSuccessStatusCode();                        
                        var jsonString = await res.Content.ReadAsStringAsync();
                        dynamic jsonres = JsonConvert.DeserializeObject<object>(jsonString);
                        A = jsonres.asymmetry;
                        B = jsonres.unevenBorders;
                        C = jsonres.colorScattered;
                        D = jsonres.filledPercent;
                    }
                }
            }                        
            ViewData["Asymmetry"] = A;
            ViewData["Border"] = B;
            ViewData["Color"] = C;
            ViewData["Diameter"] = D;
            return View();
        }
        // GET: Patients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,IdNumber,SNILS,PlaceOfBirth, PlaceOfResidence, Age, passportNumber,INN,OMSNumber,name,birthDate,gender,registrationDate," +
            "previousMelanoma,previousMelanomaInFamily,nevusType,PresenceOfFreckles,ObligateFormsOfPrecancer,HormonalChanges,burns," +
            "immuneSystemDiseases,ageGroup,eyeType,skinType,hairType, hormonalChangesNew, geneticAbnormalitiesInChromosomes, melanoma, compoundMelonoma, parents, simba, relatives, numberOfMoles, nevus, birthmarks, uf, immuneSystem, XerodermaPigmentosum")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,IdNumber,SNILS,PlaceOfBirth, PlaceOfResidence, Age,passportNumber,INN,OMSNumber,name,birthDate,gender,registrationDate," +
            "previousMelanoma,previousMelanomaInFamily,nevusType,PresenceOfFreckles,ObligateFormsOfPrecancer,HormonalChanges,burns," +
            "immuneSystemDiseases,ageGroup,eyeType,skinType,hairType, hormonalChangesNew, geneticAbnormalitiesInChromosomes,melanoma, compoundMelonoma, parents, simba, relatives, numberOfMoles, nevus, birthmarks, uf, immuneSystem, XerodermaPigmentosum")] Patient patient)
        {
            if (id != patient.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.id))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(Guid id)
        {
            return _context.Patients.Any(e => e.id == id);
        }

       
    }
}
