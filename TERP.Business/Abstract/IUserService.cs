using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);

        void Update(User user);

        List<User> GetAll();

        User GetById(int id);

        User GetUserByUsername(string username);

        User GetByPersonalId(int id);

        User GetUserWithRolesByUsername(string username);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
