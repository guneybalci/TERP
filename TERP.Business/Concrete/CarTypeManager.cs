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
    public class CarTypeManager : ICarTypeService
    {
        private ICarTypeDal _carTypeDal;

        public CarTypeManager()
        {
            _carTypeDal = new EfCarTypeDal();
        }

        public List<CarType> GetAll()
        {
            return _carTypeDal.GetAll();
        }
    }
}
