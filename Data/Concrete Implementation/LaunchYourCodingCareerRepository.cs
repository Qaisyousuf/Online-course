using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class LaunchYourCodingCareerRepository:Repository<LaunchYourCodingCareer>,ILaunchYourCodingCareerRepository
    {
        public LaunchYourCodingCareerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
