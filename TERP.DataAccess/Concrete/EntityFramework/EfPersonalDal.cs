using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfPersonalDal : EfEntityRepositoryBase<Personal, TERPContext>, IPersonalDal
    {
    }
}