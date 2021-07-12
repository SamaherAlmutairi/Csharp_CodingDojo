using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LR_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace LR_.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

      [HttpGet("")]
        [HttpGet("Register")]
        
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost("Register")]

        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                
                if (dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Register");
                }

                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return RedirectToAction($"Account/{user.UserId}");
                }
            }
            else
            {
                return View("Register");
            }
        }

        [HttpGet("Login")]

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("Login")]

        public IActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.Password);
                if (result == 0)
                {
                    ModelState.AddModelError("Password", "Password does not exist!");
                    return View("Login");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return Redirect($"Account/{userInDb.UserId}");
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("Account/{User_Id}")]

        public IActionResult Account(int User_Id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            // If the user tires to access someone else's account page. This will check the UserId in session and deny access to them before redirecting them to the Login page.
            if (HttpContext.Session.GetInt32("UserId") != User_Id)
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                return RedirectToAction("Login");
            }
            // Db query which assigns a single user and their transactions to a User Object called "Current User"
            User CurrentUser = dbContext.Users.Include(user => user.Transactions).Where(user => user.UserId == User_Id).SingleOrDefault();
            if (CurrentUser.Transactions != null)
            {
                // If the user has any posted transactions, they will be listed in descending order.
                CurrentUser.Transactions = CurrentUser.Transactions.OrderByDescending(trans => trans.CreatedAt).ToList();
            }
            // Store the Current User object in a ViewBag and return the "Account" cshtml view.
            ViewBag.User = CurrentUser;
            return View("Account");
        }

        [HttpPost("Transaction")]

        public IActionResult Transaction(decimal amount)
        {
            User CurrentUser = dbContext.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            if (amount > 0)
            {
                CurrentUser.Balance += amount;
                Transaction NewTransaction = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    UserId = CurrentUser.UserId
                };
                dbContext.Add(NewTransaction);
                dbContext.SaveChanges();
                ModelState.AddModelError("Amount", "Your deposit was successful!");
                return Redirect($"Account/{CurrentUser.UserId}");
            }
            
            else
            {
                if (CurrentUser.Balance + amount < 0)
                {
                    ModelState.AddModelError("Amount", "Balance is insufficient");
                    return Redirect($"Account/{CurrentUser.UserId}");
                }
                else
                {
                    CurrentUser.Balance += amount;
                    Transaction NewTransaction = new Transaction
                    {
                        Amount = amount,
                        CreatedAt = DateTime.Now,
                        UserId = CurrentUser.UserId
                    };
                    dbContext.Add(NewTransaction);
                    dbContext.SaveChanges();
                    ModelState.AddModelError("Amount", "Your withdrawal was a success!");
                    return Redirect($"Account/{CurrentUser.UserId}");
                }
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Register");
        }
    }
}