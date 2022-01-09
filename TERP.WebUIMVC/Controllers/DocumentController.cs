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
    public class DocumentController : BaseController
    {
        private readonly IPersonalService _personalService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IDocumentService _documentService;

        public DocumentController()
        {
            _personalService = new PersonalManager();
            _carService = new CarManager();
            _userService = new UserManager();
            _documentService = new DocumentManager();
        }

        public ActionResult Index()
        {
            var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            var currentPersonal = _personalService.GetAll().FirstOrDefault(x => x.UserID == currentUser.Id);
            var currentPersonalsCar = _carService.GetAll().FirstOrDefault(x => x.PersonalID == currentPersonal.Id);
            ViewBag.Plaque = currentPersonalsCar.Plaque;
            return View();
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
                    TempData["DocumentSuccessResult"] = "Dosya Başarıyla Yüklendi.";
                }
                catch
                {
                    TempData["DocumentErrorResult"] = "Dosya Yüklenemedi.";
                }
            }

            return View();
        }
    }
}