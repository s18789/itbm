using Microsoft.AspNetCore.Mvc;
using MVCprojectOne.Models;
using MVCprojectOne.Services.CureService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Controllers
{
    public class HomeAcessController : Controller
    {
        private ICureService _service;

        public HomeAcessController(ICureService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetCures()
        {
            ViewData["Cures"] = await _service.GetCures();

            return View();
        }

        public async Task <IActionResult> DeleteCure(int cureId)
        {
            if (await _service.IsPossibleToDeleteOrUpdateCure(cureId))
            {
                return View("GetCures");
            }

            await _service.DeleteCure(cureId);

            ViewData["Cures"] = await _service.GetCures();
            return View("GetCures");
        }

        public async Task <IActionResult> ShowUpdateCureForm(int cureId)
        {
            if (await _service.IsPossibleToDeleteOrUpdateCure(cureId))
            {
                return View("GetCures");
            }

            ViewData["cureId"] = cureId;
            return View();
        }

        public async Task <IActionResult> UpdateCure(int cureId, string name)
        {
            await _service.UpdateCure(cureId, name);

            ViewData["Cures"] = await _service.GetCures();
            return View("GetCures");
        }





    }
}
