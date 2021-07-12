using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private MyContext _db;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        // here we can "inject" our context service into the constructor
        public WeddingController(MyContext context)
        {
            _db = context;
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {    if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // query all movies and user info and likes
            List<Wedding> allWedding = _db
                .Weddings   // gets all movies and properties
                .Include(m => m.Planner) // grab PostedBy nav property
                .Include(m => m.Visitors)
                .OrderBy(ea =>ea.WDate)  // grab Fans nav property
                .ToList();
            // call user info and put in viewBag
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View(allWedding);
        }
        [HttpGet("weddings/new")]
        public IActionResult New()  // Render page with form
        {
            // call user info and put in viewBag
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View();
        }
        [HttpPost("postwedding")]
        public IActionResult PostWedding(Wedding wedding)
        {
            // check release date if in past
            if (wedding.WDate < DateTime.Now)
            {
                ModelState.AddModelError("WDate", "Release Date must be in the past");
            }
            // run validation
            if (ModelState.IsValid)
            {
                // store movie in db
                wedding.UserId = (int)uid;
                _db.Weddings.Add(wedding);
                _db.SaveChanges();
                return Redirect($"/weddings/{wedding.WeddingId}");
                // this below one does the same thing
                // return RedirectToAction("Movies", new { movieId = movie.MovieId });
            }
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View("New");
        }

        [HttpGet("weddings/{weddingId}")]
        public IActionResult Weddings(int weddingId)
        {
            // query the movie by id
            Wedding thisWedding = _db
            .Weddings
            .Include(m => m.Planner)
            .Include(m => m.Visitors)
            .ThenInclude(f => f.Invited)
            .FirstOrDefault(m => m.WeddingId == weddingId);
            // call user info and put in viewBag
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View(thisWedding);
        }
        [HttpGet("delete/{weddingId}")]  // movieId has to match the asp-route-movieId
        public IActionResult Delete(int weddingId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // query movies db by id
            Wedding delWedding = _db.Weddings.FirstOrDefault(m => m.WeddingId == weddingId);
            // remove from db
            _db.Weddings.Remove(delWedding);
            // save changes
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("guest/{weddingId}")]
        public IActionResult Guest(int weddingId)
        {
            // create new Like instance
            Guest guest = new Guest();
            // reassign UserId and MovieId
            guest.UserId = (int)uid;
            guest.WeddingId = weddingId;
            // Add to Likes table in db
            _db.Guests.Add(guest);
            // save changes
            _db.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }
        [HttpGet("unguest/{weddingId}")]
        public IActionResult Unguest(int weddingId)
        {
            // query Like from db
            // must match the movieId and userId in the 1 Like relationship
            Guest unguest = _db.Guests.FirstOrDefault(l => l.InvitedTo.WeddingId == weddingId && l.Invited.UserId == (int)uid);
            // Add to Likes table in db
            _db.Guests.Remove(unguest);
            // save changes
            _db.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }
    }
}