using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class UserbenefitsContentsRepository:Repository<UserbenefitsContents>,IUserbenefitsContentsRepository
    {
        public UserbenefitsContentsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
