using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, TERPContext>, ICarDal
    {
    }
}
