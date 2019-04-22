using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmailCampaign.Admin.Models;
using EmailCampaign.Admin.Utility;
using Microsoft.AspNetCore.Authorization;

namespace EmailCampaign.Admin.Controllers
{    
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
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

        public IActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ForbiddenError()
        {
            Response.StatusCode = 403;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public ActionResult CheckSite()
        {
            bool siteIsValid = true;

            if (siteIsValid)
                ViewBag.results = "WEBSITE IS OK";

            return View();
        }
    }
}
