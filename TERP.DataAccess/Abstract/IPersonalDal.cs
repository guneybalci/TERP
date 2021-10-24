using System.Collections.Generic;
using TERP.Entities.Concrete;

namespace TERP.DataAccess.Abstract
{
    public interface IPersonalDal : IEntityRepositoryBase<Personal>
    {
        List<Personal> GetAllWithUserAndRole();

    }
}