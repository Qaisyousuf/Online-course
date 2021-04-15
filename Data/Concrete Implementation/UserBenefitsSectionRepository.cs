using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class UserBenefitsSectionRepository:Repository<UserBenefitsSection>,IUserBenefitsSectionRepository
    {
        public UserBenefitsSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
