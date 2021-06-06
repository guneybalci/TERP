using System;
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
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager()
        {
            _roleDal = new EfRoleDal();
        }
        public List<Role> GetAll()
        {
            return _roleDal.GetAll();
        }
    }
}
