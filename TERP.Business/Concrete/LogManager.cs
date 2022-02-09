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
    public class LogManager : ILogService
    {
        private ILogDal _logDal;

        public LogManager()
        {
            _logDal = new EfLogDal();
        }

        public void Add(Log log)
        {
            _logDal.Add(log);
        }

        public List<Log> GetAll()
        {
            return _logDal.GetAll();
        }
    }
}
