using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        void Add(Car car);

        void DeleteById(int id);

        void Update(Car car);

        Car GetById(int id);
    }
}
