using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringAspNetCoreApps.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ConfiguringAspNetCoreApps.Controllers
{
    public class HomeController : Controller
    {
        private UpTimeService timer;
        private ILogger<HomeController> homeLogger;

        public HomeController(UpTimeService _timer, ILogger<HomeController> logger)
        {
            timer = _timer;
            homeLogger = logger;
        }

        public ViewResult Index(bool throwException = false)
        {
            homeLogger.LogInformation($"Handled {Request.Path} after {timer.Uptime}ms" +
                $" from application startup");

            if (throwException)
                throw new NullReferenceException("Null exception as you set throwException true");
            Dictionary<string, string> details = new Dictionary<string, string>()
            {
                ["Message"] = "This is the Index action",
                ["UpTime"] = $"{timer.Uptime} ms"
            };
            return View(details);
        }

        public ViewResult Error() =>
            View("Index", new Dictionary<string, string>()
            {
                ["Message"] = "This is the Error action"
            });


    }
}
