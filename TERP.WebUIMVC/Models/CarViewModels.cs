using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using TERP.Entities.Concrete;

namespace TERP.WebUIMVC.Models
{
    public class CarViewModel
    {
        public List<Personal> PersonalList { get; set; }
        public List<Car> CarList { get; set; }
        public List<CarType> CarTypeList { get; set; }
    }

    public class AddCarViewModel
    {
        public int CarID { get; set; }
        public string Plaque { get; set; }
        public int PersonalID { get; set; }
        public string Status { get; set; }
        public int CarTypeID { get; set; }
    }

    public class UpdateCarViewModel
    {
        public int CarID { get; set; }
        public string Plaque { get; set; }
        public int? PersonalID { get; set; }
        public bool Status { get; set; }
        public int CarTypeID { get; set; }
    }
}