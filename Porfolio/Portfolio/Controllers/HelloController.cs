using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           // Here we assign the value "Hello World!" to the property .Example
    // Property names are arbitrary and can be whatever you like
    ViewBag.Example = "Hello World!";
    return View();
        }

          [HttpPost]
    [Route("/result")]
    public IActionResult Info(string fname, string locations, string languages, string comment)
    {
      ViewBag.fname = fname; 
      ViewBag.locations = locations; 
      ViewBag.languages = languages;
      ViewBag.comment = comment; 
      return View("Info");
    }
        // [HttpGet]
        // [Route("projects")]
        // public ViewResult Info()
        // {
        //     // Same logic for serving a view applies
        //     // if we provide the exact view name
        //     return View("Info");
        // }
        // // You may also serve the same view twice from additional actions
        
        // [HttpGet]
        // [Route("cantact")]
        // public ViewResult Elsewhere()
        // {
        //     // This would be a case where we have to specify the file name
        //     return View("Contact");
        // }
    }
}