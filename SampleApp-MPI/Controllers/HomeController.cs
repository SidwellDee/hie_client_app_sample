using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SampleApp_MPI.Models;
using SampleApp_MPI.Utilities;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SampleApp_MPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new Search());
        }

        public IActionResult Create() 
        {
            return View(new Patient());
        }

        [HttpPost]
        public IActionResult Create(Patient patient) 
        {
            
            if (ModelState.IsValid)
            {
                patient.PatientId = Guid.NewGuid();
                patient.AlternateId = $"H001{new Random().Next(101010, 999999)}-{new Random().Next(1, 9)}";
                patient.Inkhundla = "Unspecified";
                patient.Chiefdom = "Unspecified";

                var resource = FHIRParser.AddPatientResource(patient);

                if (resource.IsCompletedSuccessfully)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(patient);
        }

        public async Task<IActionResult> Search()
        {
            var result = await FHIRParser.GetPatientResource("f634c0c6-e23b-42a6-9a1b-30486795d1a1");
            
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}