using System.Collections.Generic;
using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;
using System.Data.Entity;
using System.Linq;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfDocumentDal : EfEntityRepositoryBase<Document, TERPContext>, IDocumentDal
    {
        public List<Document> GetAllWithPersonalAndCar()
        {
            using (var context = new TERPContext())
            {
                return context.Documents.Include(x => x.Car).Include(x => x.Personal).ToList();
            }
        }

        public List<Document> GetAllWithPersonalAndCarByPersonalId(int id)
        {
            using (TERPContext context = new TERPContext())
            {
                return context.Documents.Include(x => x.Car).Include(x => x.Personal).Where(x => x.PersonalID == id).ToList();
            }
        }
    }
}