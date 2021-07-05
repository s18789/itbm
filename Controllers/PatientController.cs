using Microsoft.AspNetCore.Mvc;
using MVCprojectOne.Services.PatientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetPatients()
        {
            ViewData["Patients"] = await _service.GetPatients();

            return View();
        }

        public async Task<IActionResult> ShowUpdatePatientForm(string personalNumber)
        {
            if(await _service.IsPossibleToUpdateOrDeletePatient(personalNumber))
            {
                return View("GetPatients");
            }

            ViewData["personalNumber"] = personalNumber;
            return View();
        }

        public async Task <IActionResult> UpdatePatient(string personalNumber, string firstName, string lastName)
        {
            await _service.UpdatePatient(personalNumber, firstName, lastName);

            ViewData["Patients"] = await _service.GetPatients();
            return View("GetPatients");
        }

        public async Task <IActionResult> DeletePatient(string personalNumber)
        {
            if (await _service.IsPossibleToUpdateOrDeletePatient(personalNumber))
            {
                return View("GetPatients");
            }

            await _service.DeletePatient(personalNumber);

            ViewData["Patients"] = await _service.GetPatients();
            return View("GetPatients");
        }
    }
}
