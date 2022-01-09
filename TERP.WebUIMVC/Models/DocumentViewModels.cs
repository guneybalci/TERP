using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TERP.WebUIMVC.Models
{
    public class UploadDocumentFileViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string FileDescription { get; set; }
    }
}