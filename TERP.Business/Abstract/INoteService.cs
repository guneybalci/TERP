using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface INoteService
    {
        List<Note> GetAll();
        Note GetById (int id);
        void Add(Note note);

        void Delete(Note note);
    }
}
