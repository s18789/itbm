using Microsoft.AspNetCore.Mvc;
using MVCprojectOne.Services.DoctorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetDoctors()
        {
            ViewData["Doctors"] = await _service.GetDoctors();

            return View();
        }

        public async Task<IActionResult> ShowUpdateDoctorForm(string doctorPersonalNumber)
        {
            if (await _service.IsPossibleToDeleteOrUpdateDoctor(doctorPersonalNumber))
            {
                return View("GetDoctors");
            }

            ViewData["doctorPersonalNumber"] = doctorPersonalNumber;
            return View();
        }

        public async Task <IActionResult> UpdateDoctor(string personalNumber, string firstName, string lastName)
        {
            await _service.UpdateDoctor(personalNumber, firstName, lastName);

            ViewData["Doctors"] = await _service.GetDoctors();
            return View("GetDoctors");
        }

        public async Task <IActionResult> DeleteDoctor (string doctorPersonalNumber)
        {
            if(await _service.IsPossibleToDeleteOrUpdateDoctor(doctorPersonalNumber))
            {
                return View("GetDoctors");
            }

            await _service.DeleteDoctor(doctorPersonalNumber);

            ViewData["Doctors"] = await _service.GetDoctors();
            return View("GetDoctors");
        }
    }
}
