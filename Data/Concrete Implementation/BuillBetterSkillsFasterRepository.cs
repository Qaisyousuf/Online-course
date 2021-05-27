using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class BuillBetterSkillsFasterRepository:Repository<BuillBetterSkillsFaster>,IBuillBetterSkillsFasterRepository
    {
        public BuillBetterSkillsFasterRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
