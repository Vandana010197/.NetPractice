using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext DbContext;
        public CustomerController(AppDbContext Context)
        {
            DbContext = Context;
        }
        public IActionResult Index()
        {
        
            List<Location> locations = DbContext.Locations.ToList();
            return View(locations);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            DbContext.Customers.Add(customer);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }   
}
