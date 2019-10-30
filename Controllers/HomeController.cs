using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS4200Team11.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We treat our culture with the same importance as we do our business strategy.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information:";

            return View();
        }

        public ActionResult CoreValues()
            {

                return View();
            }
        
    }
}