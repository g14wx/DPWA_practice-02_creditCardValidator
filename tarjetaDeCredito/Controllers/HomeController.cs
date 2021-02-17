using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CreditCardValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using tarjetaDeCredito.Models;

namespace tarjetaDeCredito.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Resolve(Home home)
        {
            CreditCardDetector validator = new CreditCardDetector(home.no);
            Home homeValidate = new Home();
            homeValidate.no = home.no;
            homeValidate.isValid = validator.IsValid();
            homeValidate.brand = validator.BrandName;
            DateTime currentDate = DateTime.UtcNow;
            DateTime creditCardDate = new DateTime(int.Parse( home.year), int.Parse(home.month),currentDate.Day);
            int comparation = DateTime.Compare(currentDate, creditCardDate);
            homeValidate.isExpired = comparation < 0;
            return View("Index",homeValidate);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}