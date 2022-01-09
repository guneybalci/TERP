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
    [CustomAuthorize(Roles = ("Koneks Admin"))]
    public class UserController : BaseController
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IPersonalService _personalService;

        public UserController()
        {
            _userService = new UserManager();
            _roleService = new RoleManager();
            _personalService = new PersonalManager();
        }

        public ActionResult Index()
        {
            ViewBag.Roles = _roleService.GetAll();

            var userList = _userService.GetAll().Where(x => !x.IsDeleted).ToList();
            return View(userList);
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        public ActionResult Add()
        {
            return View(new UserViewModel { Roles = GetAllRoles(), AddUserViewModel = new AddUserViewModel() });
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddUserViewModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                TempData["UserErrorResult"] = "Şifreler birbiri ile eşleşmemektedir.!";
                return View("Add", new UserViewModel { AddUserViewModel = model, Roles = GetAllRoles() });
            }
            if (_userService.GetUserByUsername(model.Username) == null)
            {
                _userService.Add(new User()
                {
                    Username = model.Username,
                    Password = model.Password,
                    IsActive = true,
                    IsDeleted = false,
                    RoleID = model.RoleID,
                }
                  );
                TempData["UserSuccessResult"] = "Yeni kullanıcı oluşturuldu.";
            }
            else
            {
                TempData["UserErrorResult"] = "Böyle bir kullanıcı adı zaten daha önce kayıt yapılmış. Farklı bir kullanıcı adı giriniz!";

            }



            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedUser = _userService.GetById(id);
            deletedUser.IsDeleted = true;
            _userService.Update(deletedUser);
            TempData["UserSuccessResult"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction("Index");
        }

        List<Role> GetAllRoles()
        {
            return _roleService.GetAll();
        }

        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            var currentUser = _userService.GetAll().Select(x => new
            {
                Id = x.Id,
                UserName = x.Username,
                RoleId = x.RoleID,
            }).FirstOrDefault(x => x.Id == id);
            return Json(currentUser, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(UpdateUser model)
        {
            var updatedUser = _userService.GetById(model.Id);
            if (model.Username != updatedUser.Username && _userService.GetUserByUsername(model.Username) != null)
            {
                TempData["UserErrorResult"] = "Böyle bir kullanıcı adı zaten daha önce kayıt yapılmış. Farklı bir kullanıcı adı giriniz!";
            }
            else
            {
                updatedUser.RoleID = model.RoleID;
                updatedUser.Username = model.Username;
                _userService.Update(updatedUser);
                TempData["UserSuccessResult"] = "Personel bilgileri güncellendi";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var changedUserStatus = _userService.GetById(id);
            if (changedUserStatus != null)
                changedUserStatus.IsActive = !changedUserStatus.IsActive;
            try
            {
                _userService.Update(changedUserStatus);
                TempData["UserSuccessResult"] = "Kullanıcı durumu güncellendi.";
            }
            catch
            {
                TempData["UserErrorResult"] = "Kullanıcı durumu güncellenemedi!";
            }

            return RedirectToAction("Index");
        }
    }
}