using TERP.DataAccess.Abstract;
using TERP.DataAccess.Concrete.EntityFramework.Contexts;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Concrete.EntityFramework
{
    public class EfCarTypeDal : EfEntityRepositoryBase<CarType, TERPContext>, ICarTypeDal
    {
    }
}