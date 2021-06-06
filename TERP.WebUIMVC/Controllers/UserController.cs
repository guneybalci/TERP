using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.Entities.Concrete;
using TERP.WebUIMVC.Models;

namespace TERP.WebUIMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public UserController()
        {
            _userService = new UserManager();
            _roleService = new RoleManager();
        }

        public ActionResult Index()
        {

            return View(new UserViewModel { Roles = GetAllRoles(), AddUserViewModel = new AddUserViewModel() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddUserViewModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                TempData["UserErrorResult"] = "Şifreler birbiri ile eşleşmemektedir.!";
                return View("Index", new UserViewModel { AddUserViewModel = model, Roles = GetAllRoles() });
            }
            _userService.Add(new User()
            {
                Username = model.Username,
                Password = model.Password,
                IsActive = true,
                IsDeleted = false,
                RoleID = model.RoleID
            });
            TempData["UserSuccessResult"] = "Yeni kullanıcı oluşturuldu.";

            return RedirectToAction("Index");
        }

        List<Role> GetAllRoles()
        {
            return _roleService.GetAll();
        }
    }
}