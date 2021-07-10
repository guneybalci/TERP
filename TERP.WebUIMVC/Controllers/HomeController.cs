using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TERP.WebUIMVC.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize(Roles = "Koneks Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}