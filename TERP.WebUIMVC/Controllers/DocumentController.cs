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
    public class DocumentController : BaseController
    {
        private readonly IPersonalService _personalService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IDocumentService _documentService;
        private readonly ILogService _logService;

        public DocumentController()
        {
            _personalService = new PersonalManager();
            _carService = new CarManager();
            _userService = new UserManager();
            _documentService = new DocumentManager();
            _logService = new LogManager();
        }

        public ActionResult Index()
        {
            var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            var currentPersonal = _personalService.GetAll().FirstOrDefault(x => x.UserID == currentUser.Id);
            var currentPersonalsCar = _carService.GetAll().FirstOrDefault(x => x.PersonalID == currentPersonal.Id);
            ViewBag.Plaque = currentPersonalsCar.Plaque;

            if (!User.IsInRole("Koneks Admin") && !User.IsInRole("Koneks Muhasebe"))
            {
                var model = _documentService.GetAllWithPersonalAndCarByPersonalId(currentPersonal.Id);
                return View(model);
            }
            else
            {
                var model = _documentService.GetAllWithPersonalAndCar();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(UploadDocumentFileViewModel model)
        {
            if (model.File != null && model.File.ContentLength > 0)
            {
                try
                {
                    var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
                    var currentPersonal = _personalService.GetAll().FirstOrDefault(x => x.UserID == currentUser.Id);
                    var currentPersonalsCar = _carService.GetAll().FirstOrDefault(x => x.PersonalID == currentPersonal.Id);
                    var fileName = "~/Content/documents/" + Guid.NewGuid().ToString() + model.File.FileName;
                    var path = HttpContext.Server.MapPath(fileName);
                    model.File.SaveAs(path);
                    _documentService.Add(new Document() { FileUrl = fileName, CreatedDate = DateTime.Now, Name = model.FileDescription, CarID = currentPersonalsCar.Id, PersonalID = currentPersonal.Id });
                    _logService.Add(new Log
                    {
                        Description = $"{currentPersonal.FirstName} {currentPersonal.LastName} '{model.FileDescription}' açıklamalı yeni bir evrak ekledi.",
                        CreatedDate = DateTime.Now,
                    });
                    TempData["DocumentSuccessResult"] = "Dosya Başarıyla Yüklendi.";
                }
                catch
                {
                    TempData["DocumentErrorResult"] = "Dosya Yüklenemedi.";
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Koneks Admin")]
        public ActionResult RemoveDocument(int id)
        {
            var deletedDocument = _documentService.GetById(id);

            if (deletedDocument != null)
            {
                string fullPath = Request.MapPath(deletedDocument.FileUrl);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                }
                _documentService.Delete(deletedDocument);
            }
            return RedirectToAction("Index");
        }
    }
}