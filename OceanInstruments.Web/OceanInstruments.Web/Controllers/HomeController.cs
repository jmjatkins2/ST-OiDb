using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OceanInstruments.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //For now we aren't using Asp.Net MVC for anything, so just redirect to Angular app
            return RedirectPermanent("/App/#");
        }
    }
}
