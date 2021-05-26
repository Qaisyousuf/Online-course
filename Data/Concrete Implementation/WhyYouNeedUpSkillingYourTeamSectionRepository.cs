using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class WhyYouNeedUpSkillingYourTeamSectionRepository:Repository<WhyYouNeedUpSkillingYourTeamSection>,IWhyYouNeedUpSkillingYourTeamSectionRepository
    {
        public WhyYouNeedUpSkillingYourTeamSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
