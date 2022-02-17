using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.Entities.Concrete;
using TERP.WebUIMVC.Auth;
using TERP.WebUIMVC.Models;

namespace TERP.WebUIMVC.Controllers
{
    public class LoginController : BaseController
    {
        private IUserService _userService;

        public LoginController()
        {
            _userService = new UserManager();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectPermanent("/");
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByUsernameAndPassword(model.Username, model.Password);
                if (user != null)
                {
                    if (!user.IsDeleted && user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.LoginError = "Kullanıcı yetkiniz bulunamadı. Yöneticinizle iletişim kurunuz.";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.LoginError = "Kullanıcı Adı veya Şifre Yanlış!";
                    return View(model);
                }
            }

            return View(model);
        }

        [CustomAuthorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [CustomAuthorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var user = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Şifreniz Güncellenemedi. Lütfen tekrar deneyiniz.";
                return View();
            }

            if (ModelState.IsValid)
            {
                user.Password = model.Password;
                FormsAuthentication.SignOut();
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [CustomAuthorize(Roles = ("Koneks Admin"))]
        public ActionResult ChangePasswordByUsername(string username)
        {
            if (_userService.GetUserByUsername(username) != null)
            {
                ViewBag.Username = username;
                return View("ChangePassword");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [CustomAuthorize(Roles = ("Koneks Admin"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePasswordByUsername(ChangePasswordByUsernameViewModel model)
        {
            var user = _userService.GetUserByUsername(model.Username);
            if (model.Password != model.ConfirmPassword)
            {
                TempData["UserErrorResult"] = "Şifreler birbiri ile eşleşmemektedir! Tekrar deneyiniz.";
                return RedirectToAction("Index", "User");
            }

            if (ModelState.IsValid)
            {
                user.Password = model.Password;
                _userService.Update(user);
                TempData["UserSuccessResult"] = "Kullanıcı şifresi başarıyla güncellendi.";
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}