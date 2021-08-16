using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class UserContactRepository:Repository<UserContact>,IUserContactRepository
    {
        public UserContactRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
