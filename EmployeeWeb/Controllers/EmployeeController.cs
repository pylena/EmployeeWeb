using EmployeeWeb.Data;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly AppDBContext _db;
        public EmployeeController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employees.ToList());
        }

        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Employees.Add(employee);
            return RedirectToAction("Index");
        }
        //as get
        public IActionResult Edit(int id)
        {
            return View(_db.Employees.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Employee employee) { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Employees.Update(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_db.Employees.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
