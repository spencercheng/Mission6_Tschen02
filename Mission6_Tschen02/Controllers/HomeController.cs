using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_Tschen02.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_Tschen02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DateApplicationContext blahContext { get; set; }
        public HomeController(ILogger<HomeController> logger, DateApplicationContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PodCast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = blahContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid) {
                blahContext.Add(ar);
                blahContext.SaveChanges();
                return View("Confirmatiion",ar);
            }
            else
            {
                ViewBag.Categories = blahContext.Categories.ToList();
                return View(ar);
            }
          
        }
        [HttpGet]
        public IActionResult Movies()
        {   
             
            var applications = blahContext.Responses.Include(x=>x.Category)
                .ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();
            var application = blahContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View("MovieForm", application);
        }
        [HttpPost]
        //Edit the MovieList
        public IActionResult Edit(ApplicationResponse blah)
        {
            blahContext.Update(blah);
            blahContext.SaveChanges();
            return RedirectToAction("Movies");
        }
        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = blahContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            blahContext.Responses.Remove(ar);
            blahContext.SaveChanges();
            return RedirectToAction("Movies");
        }
        public IActionResult Privacy()
        {
           
            return View( );
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
