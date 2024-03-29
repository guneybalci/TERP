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
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager()
        {
            _carDal = new EfCarDal();
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllWithCarTypeAndPersonal()
        {
            return _carDal.GetAllWithCarTypeAndPersonal();
        }

        public Car GetCarWithCarTypeAndPersonalById(int id)
        {
            return _carDal.GetCarWithCarTypeAndPersonalById(id);
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void DeleteById(int id)
        {
            _carDal.Delete(GetById(id));
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(x => x.Id == id);
        }
    }
}
