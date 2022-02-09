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
    [CustomAuthorize]
    public class NoteController : BaseController
    {
        private INoteService _noteService;
        private IUserService _userService;
        public NoteController()
        {
            _noteService = new NoteManager();
            _userService = new UserManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(Note model)
        {
            var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            model.CreatedDate = DateTime.Now;
            model.UserID = currentUser.Id;
            _noteService.Add(model);
            var newModel = new
            {
                Id = model.Id,
                Description = model.Description,
                CreatedDate = model.CreatedDate.ToShortDateString().ToString(),
            };
            return Json(newModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllNotes()
        {
            var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            var model = _noteService.GetAll().Where(x => x.UserID == currentUser.Id).Select(x => new
            {
                Id = x.Id,
                Description = x.Description,
                CreatedDate = x.CreatedDate.ToShortDateString().ToString(),
            }).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string RemoveNoteById(int id)
        {
            var currentUser = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            var currentNote = _noteService.GetById(id);
            if (currentNote != null && currentNote.UserID == currentUser.Id)
            {
                _noteService.Delete(currentNote);
                return "success";
            }
            else return "error";
        }
    }
}