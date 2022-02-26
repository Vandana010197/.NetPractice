using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject3.Models;

namespace WebProject3.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext dbContext;
        public EmployeeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Location> locations = dbContext.Locations.ToList();
            return View(locations);
        }
      /*  public IActionResult CreateEmployee(Employee Emp)
        {
            var Create = dbContext.Employees.Add(Emp);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }*/
        public IActionResult EmployeeList(int id)
        {
            List<Employee> employees = dbContext.Employees.Where(e=>e.Location.Id==id).ToList();
            return View(employees);
        }
    }
}
