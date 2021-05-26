using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class WhyYouNeedUpskillingYourTeamRepository:Repository<WhyYouNeedUpskillingYourTeam>,IWhyYouNeedUpskillingYourTeamRepository
    {
        public WhyYouNeedUpskillingYourTeamRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
