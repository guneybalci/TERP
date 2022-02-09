using System.Collections.Generic;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Abstract
{
    public interface IDocumentDal : IEntityRepositoryBase<Document>
    {
        List<Document> GetAllWithPersonalAndCarByPersonalId(int id);
        List<Document> GetAllWithPersonalAndCar();
    }
}