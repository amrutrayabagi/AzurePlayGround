using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwinAngularWeb.Controllers
{
    public class TestOwinController : Controller
    {
        // GET: TestOwin
        public ActionResult Index()
        {
            return View();
        }
    }
}