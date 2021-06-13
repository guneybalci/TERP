﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERP.Entities.Concrete;

namespace TERP.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);

        User GetByPersonalId(int id);
        void Update(User user);
    }
}
