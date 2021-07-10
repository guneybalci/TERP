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
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectPermanent("/");
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
            return RedirectPermanent("/");
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
    }
}