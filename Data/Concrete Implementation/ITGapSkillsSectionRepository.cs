using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ITGapSkillsSectionRepository:Repository<ITSkillGapSection>,IITGapSkillsSectionRepository
    {
        public ITGapSkillsSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
