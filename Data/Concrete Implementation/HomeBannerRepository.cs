using Data.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete_Implementation
{
    public class HomeBannerRepository:Repository<HomeBanner>,IHomeBannerRepository
    {
        public HomeBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
