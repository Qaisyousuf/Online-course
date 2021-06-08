using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class SiteSettingrepository:Repository<SiteSettings>,ISiteSettingrepository
    {
        public SiteSettingrepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
