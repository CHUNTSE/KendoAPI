using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoGrid.Controllers
{
    [RoutePrefix("KendoUI")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [Route("")]
        public ActionResult IndexKendo()
        {
            return View();
        }
    }
}