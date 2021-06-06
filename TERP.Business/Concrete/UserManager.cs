﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Business.Abstract;
using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework;
using TERP.Entities.Concrete;

namespace TERP.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager()
        {
            _userDal = new EfUserDal();
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }
    }
}