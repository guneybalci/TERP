﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TERP.WebUIMVC.Controllers
{
    public class SocialMediaController : BaseController
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}