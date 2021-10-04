using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.Entities.Concrete;
using TERP.WebUIMVC.Auth;

namespace TERP.WebUIMVC.Controllers
{
    public class CompanyController : BaseController
    {
        private ICompanyService _companyService;

        public CompanyController()
        {
            _companyService = new CompanyManager();
        }
        public ActionResult Index()
        {
            return View(_companyService.GetAll());
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Company model)
        {
            if (ModelState.IsValid)
            {

                if (model.Id == 0)
                {
                    try
                    {
                        _companyService.Add(model);
                        TempData["CompanySuccessResult"] = "Yeni firma bilgisi eklendi.";
                    }
                    catch
                    {
                        TempData["CompanyErrorResult"] = "Yeni firma bilgisi eklenemedi!";
                    }
                }
                else
                {
                    try
                    {
                        _companyService.Update(model);
                        TempData["CompanySuccessResult"] = "Firma bilgisi güncellendi!";
                    }
                    catch
                    {
                        TempData["CompanyErrorResult"] = "Firma bilgisi güncellenemedi!";
                    }

                }
            }
            return RedirectToAction("Index");
        }


        [CustomAuthorize(Roles = "Koneks Admin")]
        public ActionResult Remove(int id)
        {
            try
            {
                _companyService.DeleteById(id);
                TempData["CompanySuccessResult"] = "Firma bilgisi silindi!";
            }
            catch
            {
                TempData["CompanyErrorResult"] = "Firma bilgisi silinemedi!";
            }
            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        [HttpGet]
        public ActionResult GetCompanyById(int id)
        {
            var currentPersonal = _companyService.GetById(id);
            return Json(currentPersonal, JsonRequestBehavior.AllowGet);
        }
    }
}