using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TERP.WebUIMVC.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Unauthorized401ErrorPage()
        {
            return View();
        }
    }
}