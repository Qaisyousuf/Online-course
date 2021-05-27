using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class BuildBetterSkillsFasterSectionRepository:Repository<BuildBetterSkillsFasterSection>,IBuildBetterSkillsFasterSectionRepository
    {
        public BuildBetterSkillsFasterSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
