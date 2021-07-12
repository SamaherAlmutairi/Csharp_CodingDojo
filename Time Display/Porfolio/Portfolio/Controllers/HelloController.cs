using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            // will attempt to serve 
                // Views/Hello/Index.cshtml
            // or if that file isn't there:
                // Views/Shared/Index.cshtml
            return View();
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