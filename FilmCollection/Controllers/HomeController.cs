using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


//This page provides controller configuration
namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        
       
        private FilmContext _MFContext { get; set; }
        //Constructor
        public HomeController(FilmContext contextVariable)
        {
            _MFContext = contextVariable;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        
        //This is the get action
        [HttpGet]
        public IActionResult MovieForm()
        {
            
            ViewBag.Categories = _MFContext.Category.ToList();

            return View();
        }

        //This is the post action
        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if(ModelState.IsValid)
            {
                 _MFContext.Add(ar);
                 _MFContext.SaveChanges();

                 return View();
            }
            else //if invalid
            {
                ViewBag.Categories = _MFContext.Category.ToList();

                return View();
            }
           
        }

        public IActionResult MovieList()
        {
            var movies = _MFContext.R
                .Include(x => x.Category)
                //.Where(x => x.Rating != "R")
                //.OrderBy(x => x.Year)
                .ToList();
            return View(movies);
        }

        //This function recieves the id of the user-selected record
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = _MFContext.Category.ToList();

            var form = _MFContext.R.Single(x => x.ApplicationID == applicationid);

            return View("MovieForm", form);
        }

        //This function recieves the response of form
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            _MFContext.Update(blah);
            _MFContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        //This function recieves the id of the user-selected record
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = _MFContext.R.Single(x => x.ApplicationID == applicationid);
           
            return View(application);
        }

        //This function recieves the response of the user-selected button (cancel or delete)
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _MFContext.R.Remove(ar);
            _MFContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
