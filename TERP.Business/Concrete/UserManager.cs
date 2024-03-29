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

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.Get(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _userDal.Get(x => x.Username == username);
        }

        public User GetByPersonalId(int id)
        {
            return _userDal.Get(x => x.Personals.FirstOrDefault(y => y.Id == id).UserID == x.Id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User GetUserWithRolesByUsername(string username)
        {
            return _userDal.GetUserWithRolesByUsername(username);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _userDal.Get(x => x.Username == username && x.Password == password);
        }
    }
}
