using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface IPersonalService
    {
        List<Personal> GetAllWithUserAndRole();
        void Add(Personal personal);

        Personal GetById(int id);

        void Update(Personal personal);
    }
}
