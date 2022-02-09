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
    [CustomAuthorize(Roles = "Koneks Admin")]
    public class LogController : BaseController
    {
        private ILogService _logService;
        public LogController()
        {
            _logService = new LogManager();
        }
        public ActionResult Index()
        {
            var logs = _logService.GetAll();
            return View(logs);
        }
    }
}