using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebValidation.Models;

namespace WebValidation.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext DbContext;

        public EmployeeController(ApplicationDbContext Context)
        {
            DbContext = Context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = DbContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
            DbContext.Employees.Add(employee);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public IActionResult Delete(int id)
        {
            var employee = DbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (employee != null)
            {
                DbContext.Employees.Remove(employee);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public IActionResult Edit(int id)
        {
            var employee = DbContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
                DbContext.Employees.Update(employee);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
