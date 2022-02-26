using CategoryAdio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryAdio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CustomerDataAccess dataAccess;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dataAccess = new CustomerDataAccess();
        }

        public IActionResult Index()
        {
            var customer = dataAccess.GetCustomers();
            return View(customer);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
