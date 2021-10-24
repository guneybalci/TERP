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
    public class PersonalController : BaseController
    {
        private IPersonalService _personalService;
        private IUserService _userService;

        public PersonalController()
        {
            _personalService = new PersonalManager();
            _userService = new UserManager();
        }

        public ActionResult Index()
        {
            return View(new PersonalViewModel()
            {
                PersonalLists = _personalService.GetAll(),
                UserList = _userService.GetAll()
            });
        }


        [CustomAuthorize(Roles = "Koneks Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddPersonalViewModel model)
        {
            if (ModelState.IsValid)
            {
                //doğrulama olduğu zaman yapılacak işlemler,yönlendirilecek sayfa vb.
                //gizli input içerisindeki değer 0'a eşit ise ekleme işlemi gerçekleştirilecekdir.
                if (model.Id == 0)
                {
                    try
                    {
                        _personalService.Add(new Personal()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            Phone = model.Phone,
                            Adress = model.Adress,
                            UserID = model.UserID
                        });
                        TempData["PersonalSuccessResult"] = "Yeni personel bilgisi eklendi.";
                    }
                    catch
                    {
                        TempData["PersonalErrorResult"] = "Yeni personel bilgisi eklenemedi!";
                    }
                }
                else
                {
                    try
                    {
                        //gizli input içerisindeki değer 0'dan farklı ise güncelleme yapılacağı anlamındadır.
                        var updatedPersonal = _personalService.GetById(model.Id);
                        updatedPersonal.FirstName = model.FirstName;
                        updatedPersonal.LastName = model.LastName;
                        updatedPersonal.Email = model.Email;
                        updatedPersonal.Phone = model.Phone;
                        updatedPersonal.Adress = model.Adress;
                        updatedPersonal.UserID = model.UserID;
                        TempData["PersonalSuccessResult"] = "Personel bilgisi güncellendi.";
                    }
                    catch
                    {
                        TempData["PersonalErrorResult"] = "Personal bilgisi güncellenemedi";
                    }
                }

            }
            //doğrulama yapılmadığı takdirde ekrana aynı view getirilecek
            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        public ActionResult Remove(int id)
        {
            try
            {
                _personalService.DeleteById(id);
                TempData["PersonalSuccessResult"] = "Personel bilgisi silindi.";
            }
            catch
            {
                TempData["PersonalErrorResult"] = "Personal bilgisi silinemedi!";
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetPersonalById(int id)
        {
            var currentPersonalId = _personalService.GetById(id);
            return Json(currentPersonalId, JsonRequestBehavior.AllowGet);
        }
    }
}