using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;

namespace TERP.WebUIMVC.Controllers
{
    public class CarController : BaseController
    {
        private ICarService _carService;
        public CarController()
        {
            _carService = new CarManager();
        }
        public ActionResult Index()
        {
            return View(_carService.GetAll());
        }
    }
}