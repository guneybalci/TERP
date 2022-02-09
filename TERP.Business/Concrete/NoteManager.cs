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
    public class NoteManager : INoteService
    {
        private INoteDal _noteDal;

        public NoteManager()
        {
            _noteDal = new EfNoteDal();
        }

        public void Add(Note note)
        {
            _noteDal.Add(note);
        }

        public List<Note> GetAll()
        {
            return _noteDal.GetAll();
        }

        public void Delete(Note note)
        {
            _noteDal.Delete(note);
        }

        public Note GetById(int id)
        {
            return _noteDal.Get(x => x.Id == id);
        }
    }
}
