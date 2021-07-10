using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        void Add(Company company);
        void DeleteById(int id);
        void Update(Company company);

        Company GetById(int id);
    }
}
