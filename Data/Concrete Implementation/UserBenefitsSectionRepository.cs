using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class UserBenefitsSectionRepository:Repository<UserBenefitsSection>,IUserBenefitsSectionRepository
    {
        public UserBenefitsSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
