﻿using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    internal class EfTeamsDal : GenericRepository<Team>, ITeamsDal
    {
    }
}
