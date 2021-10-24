using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TERP.Entities.Concrete;

namespace TERP.WebUIMVC.Models
{
    public class PersonalViewModel
    {
        public List<Personal> PersonalLists { get; set; }
        public List<User> UserList { get; set; }
    }

    public class AddPersonalViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public int UserID { get; set; }
    }

    public class UpdatePersonalViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public int UserID { get; set; }
    }
}