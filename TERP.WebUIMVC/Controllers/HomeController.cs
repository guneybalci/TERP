using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.WebUIMVC.Models;

namespace TERP.WebUIMVC.Controllers
{
    public class HomeController : BaseController
    {

        private ICarService _carService;

        public HomeController()
        {
            _carService = new CarManager();
        }
        public ActionResult Index()
        {
            return View(new CarViewModel() { 
                CarList = _carService.GetAllWithCarTypeAndPersonal(), 
            });
        }
    }
}