using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class BuildBetterSkillsFasterSectionRepository:Repository<BuildBetterSkillsFasterSection>,IBuildBetterSkillsFasterSectionRepository
    {
        public BuildBetterSkillsFasterSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
