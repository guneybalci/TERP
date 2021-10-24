﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TERP.Entities.Concrete;

namespace TERP.WebUIMVC.Models
{
    public class UserViewModel
    {
        public List<Role> Roles { get; set; }
        public AddUserViewModel AddUserViewModel { get; set; }
    }
    public class AddUserViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int RoleID { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }

    public class UpdatePersonalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public int RoleID { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }
}