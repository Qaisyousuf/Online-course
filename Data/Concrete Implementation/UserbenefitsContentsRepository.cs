using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class UserbenefitsContentsRepository:Repository<UserbenefitsContents>,IUserbenefitsContentsRepository
    {
        public UserbenefitsContentsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
