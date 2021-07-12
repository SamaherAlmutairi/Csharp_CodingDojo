using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        
        private void setDachiInSession(Dachi dachi = null)
        {
               //    Random rand = new Random();
            // int? Fullness = HttpContext.Session.GetInt32("Fullness");
            // int? Meals = HttpContext.Session.GetInt32("Meals");
            // int randomRaise = rand.Next(5, 11);
            
            if(dachi == null)
            {
                dachi = new Dachi();
                HttpContext.Session.SetString("newGame", "true");
            }
            HttpContext.Session.SetInt32("happiness", dachi.Happiness);
            HttpContext.Session.SetInt32("fullness", dachi.Fullness);
            HttpContext.Session.SetInt32("energy", dachi.Energy);
            HttpContext.Session.SetInt32("meals", dachi.Meals);
            
        }
        private Dachi getDachiFromSession()
        {
            return new Dachi
            (
                HttpContext.Session.GetInt32("happiness"),
                HttpContext.Session.GetInt32("fullness"),
                HttpContext.Session.GetInt32("energy"),
                HttpContext.Session.GetInt32("meals")
            );
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
         
            if(HttpContext.Session.GetString("newGame") == null)
                setDachiInSession();

            return View(getDachiFromSession());
        }


        [HttpGet("game/{gameType}")]
        public IActionResult Play(string gameType)
        {
            Dachi currDachi = getDachiFromSession();
            TempData["message"] = currDachi.Play(gameType);
            setDachiInSession(currDachi); 
            return RedirectToAction("Index");     
        }


        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}