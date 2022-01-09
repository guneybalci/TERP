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
            var personals = _personalService.GetAllWithUserAndRole().OrderByDescending(x => x.Id)
                .Where(x => x.User.IsDeleted == false).ToList();
            return View(personals);
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

            _personalService.Add(new Personal()
            {
                FirstName = model.Name,
                LastName = model.Lastname,
                Adress = model.Adress,
                Email = model.Email,
                IsDeleted = false,
                Phone = model.Phone,
                User = new User()
                {
                    Username = model.Username,
                    Password = model.Password,
                    IsActive = true,
                    IsDeleted = false,
                    RoleID = model.RoleID,
                }
            });

            TempData["UserSuccessResult"] = "Yeni kullanıcı oluşturuldu.";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //var deletedPersonal = _personalService.GetById(id);
            //deletedPersonal.IsDeleted = true;
            //_personalService.Update(deletedPersonal);
            var deletedUser = _userService.GetById(id);
            deletedUser.IsActive = false;
            deletedUser.IsDeleted = true;
            _userService.Update(deletedUser);
            TempData["UserSuccessResult"] = "Kullanıcı başarıyla silindi";
            return RedirectToAction("Index");
        }

        List<Role> GetAllRoles()
        {
            return _roleService.GetAll();
        }

        [HttpGet]
        public ActionResult GetPersonalByIdWithUserAndRole(int id)
        {
            var currentPersonal = _personalService.GetAllWithUserAndRole().Select(x => new
            {
                Id = x.Id,
                Email = x.Email,
                Phone = x.Phone,
                Adress = x.Adress,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.User.Username,
                RoleId = x.User.RoleID,
            }).FirstOrDefault(x => x.Id == id);
            return Json(currentPersonal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(UpdatePersonalUser model)
        {
            var updatedPersonal = _personalService.GetById(model.Id);
            updatedPersonal.FirstName = model.Name;
            updatedPersonal.LastName = model.Lastname;
            updatedPersonal.Email = model.Email;
            updatedPersonal.Phone = model.Phone;
            updatedPersonal.Adress = model.Adress;
            _personalService.Update(updatedPersonal);
            var updatedUser = _userService.GetByPersonalId(model.Id);
            updatedUser.RoleID = model.RoleID;
            updatedUser.Username = model.Username;
            _userService.Update(updatedUser);
            TempData["UserSuccessResult"] = "Personel bilgileri güncellendi";
            return RedirectToAction("Index");
        }
    }
}