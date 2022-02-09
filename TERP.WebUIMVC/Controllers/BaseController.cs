using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.Business.Abstract;
using TERP.Business.Concrete;
using TERP.WebUIMVC.Auth;

namespace TERP.WebUIMVC.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
        private ICarService _carService;
        private ILogService _logService;
        private INoteService _noteService;
        public BaseController()
        {
            _carService = new CarManager();
            var model = _carService.GetAllWithCarTypeAndPersonal();
            ViewBag.HeaderInfo = model;

            _logService = new LogManager();
            var logModel = _logService.GetAll().Where(x => x.CreatedDate.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList();
            ViewBag.Logs = logModel;
        }
    }
}