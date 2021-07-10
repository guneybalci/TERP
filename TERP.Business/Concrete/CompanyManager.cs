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
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager()
        {
            _companyDal = new EfCompanyDal();
        }
        public List<Company> GetAll()
        {
            return _companyDal.GetAll();
        }

        public void Add(Company company)
        {
            _companyDal.Add(company);
        }

        public void DeleteById(int id)
        {
            _companyDal.Delete(GetById(id));
        }

        public void Update(Company company)
        {
            _companyDal.Update(company);
        }

        public Company GetById(int id)
        {
            return _companyDal.Get(x => x.Id == id);
        }
    }
}
