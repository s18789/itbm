using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCprojectOne.Controllers
{
    public class StepTwoController : Controller
    {
        [HttpGet]
        public IActionResult RStepTwoController(string login, string password)
        {
            ViewData["log"] = login;
            ViewData["pas"] = password;
            return View("RStepTwoController");
        }
    }
}
