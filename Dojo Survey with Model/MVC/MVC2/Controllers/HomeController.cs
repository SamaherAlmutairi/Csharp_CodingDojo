using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class HomeController : Controller
  {
     
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost("survey")]
        public IActionResult ProcessForm(Survey result)
        {
            
            // passing result as view model//sultion of platform
            return View("Show", result);
        }
    }
}

        // [HttpGet("userinfo")]
        // public IActionResult UserDetail()
        // {
        //     // While being hard-coded here, this user instance will eventually come from our DB
        //     User someUser = new User()
        //     {
        //         FirstName = "Samaher",
        //         LastName = "Saleh"
        //     };
        //     // Here we pass this instance to our View
        //     return View(someUser);
        //     // If we also need to include the name of our View, we pass our instance as a second argument
        //     // return View("OtherView", someUser);
        
    
