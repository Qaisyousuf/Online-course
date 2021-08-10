using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class DashBoardRepository:Repository<DashboardUsers>,IDashboardUserRepository
    {
        public DashBoardRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
