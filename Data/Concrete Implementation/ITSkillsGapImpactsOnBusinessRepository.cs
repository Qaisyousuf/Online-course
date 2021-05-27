using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ITSkillsGapImpactsOnBusinessRepository:Repository<ITSkillsGapImpactsOnBusiness>,IITSkillsGapImpactsOnBusinessRepository
    {
        public ITSkillsGapImpactsOnBusinessRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
