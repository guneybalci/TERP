using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface ILogService
    {
        List<Log> GetAll();

        void Add(Log log);
    }
}
