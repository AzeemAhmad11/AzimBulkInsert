using BulkInsert.Models;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BulkInsert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var TotalEmp = _db.Employee.Count();
            ViewBag.TotalEmployee = TotalEmp;
            return View();
        }

        [HttpPost]
        public IActionResult Save()
        {
            List<Employee> employee = new List<Employee>();
            employee = GetDataforInsert();
            _db.BulkInsert(employee);
            return RedirectToAction("Index");
        }

        public static List<Employee> GetDataforInsert()
        {
            List<Employee> employee = new List<Employee>();
            for (int i = 0; i < 100000; i++)
            {
                employee.Add(new Employee()
                {
                    Name="Employee_" +i,
                    Department="Department_" +i,
                    City = "City_" +i
                });
                
            }
            return employee;
        }
    }
}
