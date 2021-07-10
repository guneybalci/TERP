using System.Collections.Generic;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        User GetUserWithRolesByUsername(string username);
    }
}