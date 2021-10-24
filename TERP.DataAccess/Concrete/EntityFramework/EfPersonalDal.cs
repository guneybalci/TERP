using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfPersonalDal : EfEntityRepositoryBase<Personal, TERPContext>, IPersonalDal
    {
        public List<Personal> GetAllWithUserAndRole()
        {
            using (TERPContext context = new TERPContext())
            {
                return context.Personals.Include(x => x.User).Include(x => x.User.Role).ToList();
            }
        }

        //public Personal GetPersonalWithUsersById(int id)
        //{
        //    using (TERPContext context = new TERPContext())
        //    {
        //        return context.Personals.Include(x => x.User).FirstOrDefault(x=> x.Id == id);
        //    }
        //}

    }
}