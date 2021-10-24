using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.Entities.Concrete;
using TERP.WebUIMVC.Auth;
using TERP.WebUIMVC.Models;

namespace TERP.WebUIMVC.Controllers
{
    [CustomAuthorize(Roles = "Koneks Admin")]
    public class CarController : BaseController
    {
        private ICarService _carService;
        private IPersonalService _personalService;
        private ICarTypeService _carTypeService;


        public CarController()
        {
            _carService = new CarManager();
            _personalService = new PersonalManager();
            _carTypeService = new CarTypeManager();
        }
        public ActionResult Index()
        {
            return View(new CarViewModel()
            {
                CarList = _carService.GetAllWithCarTypeAndPersonal(),
                PersonalList = _personalService.GetAll(),
                CarTypeList = _carTypeService.GetAll()
            });
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddCarViewModel model)
        {

            if (model.CarID == 0)
            {
                try
                {
                    _carService.Add(new Car()
                    {
                        Plaque = model.Plaque,
                        CarTypeID = model.CarTypeID,
                        PersonalID = model.PersonalID,
                        Status = model.Status == "1"
                    });
                    TempData["CarControlSuccessResult"] = "Yeni araç eklendi.";
                }
                catch
                {
                    TempData["CarControlErrorResult"] = "Yeni araç eklenemedi!";
                }

            }
            else
            {

                try
                {
                    var updatedCar = _carService.GetById(model.CarID);
                    updatedCar.Plaque = model.Plaque;
                    updatedCar.CarTypeID = model.CarTypeID;
                    updatedCar.PersonalID = model.PersonalID;
                    updatedCar.Status = model.Status == "1";
                    _carService.Update(updatedCar);
                    TempData["CarControlSuccessResult"] = "Araç başarıyla güncellendi.";
                }
                catch
                {
                    TempData["CarControlErrorResult"] = "Araç güncellenemedi!";
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetCarById(int id)
        {
            var currentCar = _carService.GetCarWithCarTypeAndPersonalById(id);
            var returnedData = new UpdateCarViewModel()
            {
                CarID = currentCar.Id,
                CarTypeID = currentCar.CarTypeID,
                PersonalID = currentCar.PersonalID,
                Plaque = currentCar.Plaque,
                Status = currentCar.Status
            };
            return Json(returnedData, JsonRequestBehavior.AllowGet);
        }
    }
}