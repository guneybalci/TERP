using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface IDocumentService
    {
        void Add(Document document);

        void Update(Document document);

        void Delete(Document document);

        List<Document> GetAll();

        Document GetById(int id);

        List<Document> GetAllWithPersonalAndCarByPersonalId(int id);

        List<Document> GetAllWithPersonalAndCar();

    }
}
