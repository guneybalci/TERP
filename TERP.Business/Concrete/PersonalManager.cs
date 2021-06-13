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
    public class PersonalManager : IPersonalService
    {
        private IPersonalDal _personalDal;

        public PersonalManager()
        {
            _personalDal = new EfPersonalDal();
        }

        public List<Personal> GetAllWithUserAndRole()
        {
            return _personalDal.GetAllWithUserAndRole();
        }

        public void Add(Personal personal)
        {
            _personalDal.Add(personal);
        }

        public Personal GetById(int id)
        {
            return _personalDal.Get(x => x.Id == id);
        }

        public void Update(Personal personal)
        {
            _personalDal.Update(personal);
        }
    }
}
