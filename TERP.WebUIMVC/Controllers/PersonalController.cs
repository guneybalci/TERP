using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Entities.Concrete;

namespace TERP.WebUIMVC.Controllers
{
    public class PersonalController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Personal model)
        {

            return RedirectToAction("Index");
        }
    }
}