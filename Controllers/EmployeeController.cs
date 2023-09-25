using Microsoft.AspNetCore.Mvc;
using NextCrudProject.Data;
using NextCrudProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextCrudProject.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly ApplicationContext context;
        private int id;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.employees.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Address = model.Address,
                    phone = model.phone,
                    salary = model.salary,

                };
                context.employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "record saved";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "recod empty";
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var emp = context.employees.SingleOrDefault(e => e.Id == id);
            context.employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "record deleted";
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var emp = context.employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Id = emp.Id,
                Email = emp.Email,
                Address = emp.Address,
                phone = emp.phone,
                salary = emp.salary,

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id=model.Id,
                Email=model.Email,
                Address=model.Address,
                phone=model.phone,
                salary=model.salary,

            };
            context.employees.Update(emp);
            context.SaveChanges();
            TempData["eroor"] = "record updated";
            return RedirectToAction("index");

        }

    }
}



