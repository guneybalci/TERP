using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, TERPContext>, IUserDal
    {
        public User GetUserWithRolesByUsername(string username)
        {
            using (TERPContext context = new TERPContext())
            {
                return context.Users.Include(x => x.Role).FirstOrDefault(x => x.Username == username);
            }
        }
    }
}