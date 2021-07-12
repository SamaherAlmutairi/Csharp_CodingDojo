using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = _context.Dishes.ToList();
            ViewBag.AllDishes = AllDishes;
            Container container = new Container();
            container.DishList = AllDishes;
            return View(container);
        }


        [HttpGet("New")]
        public IActionResult New()
        {
           
            Container container = new Container();
            container.Dish = new Dish();
            return View(container);
        }

        [HttpPost("process")]
        public IActionResult Process(Dish dish)
        {
            Console.WriteLine("Made it to Process");
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            Console.WriteLine($"Successfully saved! {dish.Name}");
            return RedirectToAction("Index");
        }


        [HttpPost("update/{id}")]
        public IActionResult Update(int id, Dish m)
        {
            Console.WriteLine($"got id: {id}");
            Dish thisDish = _context.Dishes.FirstOrDefault(m => m.DishId == id);
            thisDish.Name = m.Name;
            thisDish.Chef = m.Chef;
            thisDish.Description = m.Description;
            thisDish.Calories = m.Calories;
            thisDish.Tastiness = m.Tastiness;
            thisDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            Console.WriteLine($"Successfully saved! {thisDish.Name}");
            return RedirectToAction("Index");
        }

        [HttpGet("info/{id}")]
        public IActionResult Info(int id)
        {
       
            var newDish = _context.Dishes.Where(m => m.DishId == id);
            Dish firstDish= _context.Dishes.FirstOrDefault(m => m.DishId == id);
            return View(firstDish);
        }
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Dish dish = _context.Dishes.FirstOrDefault(m => m.DishId == id);
            return View(dish);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            Dish deldish = _context.Dishes.FirstOrDefault(m => m.DishId == id);
            _context.Dishes.Remove(deldish);
            _context.SaveChanges();
            Console.WriteLine("Deleting movie successfully");
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}