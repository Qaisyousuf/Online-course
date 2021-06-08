using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class WhyYouNeedUpSkillingYourTeamSectionRepository:Repository<WhyYouNeedUpSkillingYourTeamSection>,IWhyYouNeedUpSkillingYourTeamSectionRepository
    {
        public WhyYouNeedUpSkillingYourTeamSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
