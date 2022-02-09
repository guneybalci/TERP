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
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;

        public DocumentManager()
        {
            _documentDal = new EfDocumentDal();
        }

        public void Add(Document document)
        {
            _documentDal.Add(document);
        }

        public void Delete(Document document)
        {
            _documentDal.Delete(document);
        }

        public List<Document> GetAll()
        {
            return _documentDal.GetAll();
        }

        public List<Document> GetAllWithPersonalAndCar()
        {
            return _documentDal.GetAllWithPersonalAndCar();
        }

        public List<Document> GetAllWithPersonalAndCarByPersonalId(int id)
        {
            return _documentDal.GetAllWithPersonalAndCarByPersonalId(id);
        }

        public Document GetById(int id)
        {
            return _documentDal.Get(x => x.Id == id);
        }

        public void Update(Document document)
        {
            _documentDal.Update(document);
        }
    }
}
