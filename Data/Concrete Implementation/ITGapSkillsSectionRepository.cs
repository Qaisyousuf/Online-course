using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ITGapSkillsSectionRepository:Repository<ITSkillGapSection>,IITGapSkillsSectionRepository
    {
        public ITGapSkillsSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
