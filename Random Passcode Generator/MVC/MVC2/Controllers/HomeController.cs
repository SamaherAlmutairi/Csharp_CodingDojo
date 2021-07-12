using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace MVC2.Controllers
{
    public class HomeController : Controller
  {
 private string generatePasscode(int size)
        {
            Random r = new Random();
            string values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] chars = new char[size];  
            for(var i = 0; i < size; i++){
                chars[i] = values[r.Next(0, values.Length)];
            }
            return new string(chars);  
            
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
        
            if(HttpContext.Session.GetInt32("times") == null)
                HttpContext.Session.SetInt32("times", 0);

            ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            ViewBag.Times = HttpContext.Session.GetInt32("times");

            return View();
        }
        [HttpGet("new")]
        public IActionResult NewPasscode()
        {
            int? times = HttpContext.Session.GetInt32("times");
            times++;
            HttpContext.Session.SetInt32("times", (int)times);
            HttpContext.Session.SetString("passcode", generatePasscode(14));
            return RedirectToAction("Index");
        }
}
}


        
    
