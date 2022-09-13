using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tryajax.Data;
using Tryajax.Models;

namespace Tryajax.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _ab;

        public HomeController(AppDbContext db)
        {
            _ab = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            var objStudentlist = _ab.Students;
            var objStudent = _ab.Students;
            //Console.writeline(typeof(objStudentlist));
            //var objStudentlist
            ViewBag.student = objStudent;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                _ab.Students.Add(obj);
                _ab.SaveChanges();
                TempData["Success"] = "Category created Succesfuly";
                
                return View();
            }
            //return Model with error
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
