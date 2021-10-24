using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public List<Car> GetAllWithCarTypeAndPersonal()
        {
            using (TERPContext context = new TERPContext())
            {
                return context.Cars.Include(x => x.CarType).Include(x => x.Personal).ToList();
            }
        }

        public Car GetCarWithCarTypeAndPersonalById(int id)
        {
            using (TERPContext context = new TERPContext())
            {
                return context.Cars.Include(x => x.CarType).Include((x => x.Personal)).FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
