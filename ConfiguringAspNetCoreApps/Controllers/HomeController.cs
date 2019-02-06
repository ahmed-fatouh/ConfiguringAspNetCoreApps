using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringAspNetCoreApps.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Dictionary<string, string> details = new Dictionary<string, string>()
            {
                ["Message"] = "This is the Index action"
            };
            return View(details);
        }


    }
}
