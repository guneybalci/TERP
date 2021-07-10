using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TERP.WebUIMVC.Auth;

namespace TERP.WebUIMVC.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
    }
}