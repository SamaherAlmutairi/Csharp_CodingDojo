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
        // [HttpGet]
        // [Route("")]
        [HttpGet("")]  //shorthand
        public IActionResult Index()
        {
           
       string message = "YOLO";
      return View("Index", message);    
      
          }

        // [HttpGet("new/{number}")]
        // public IActionResult New(int number)
        // {
        //     ViewBag.Number = number;
        //     return View();
        // }


    [HttpGet("users")]
    public IActionResult Show()
    {
    User u1 = new User("Samaher", "Saleh");
    User u2 = new User("Rana", "Ahmed");
    User u3 = new User("Noura", "Bader");
    User u4 = new User("GHaidaa", "Nasser");
    List<User> users = new List<User>(); 
    {
        users.Add(u1);
        users.Add(u2);
        users.Add(u3);
        users.Add(u4);
    }
        // Here we pass this instance to our View
    return View("Show", users);
    }

      [HttpGet("numbers")]
    public IActionResult New()
    {
      int[] num = new int[] {1, 2, 3, 10, 43,5};
      return View("New", num);
    }

      [HttpGet("user")]
        public IActionResult UserDetail()
        {
            // While being hard-coded here, this user instance will eventually come from our DB
            User someUser = new User()
            {
                FirstName = "Samaher",
                LastName = "Saleh"
            };
            // Here we pass this instance to our View
            return View(someUser);
        }
        //     // return RedirectToAction("Show");
        // }

        // [HttpGet("result")]
        // public IActionResult Show()
        // {
        //     return View();
        // }

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
        }
    }
