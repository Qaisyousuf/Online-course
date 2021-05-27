using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class UpSkillingEmployeesRepository:Repository<UpskillingEmployee>,IUpSkillingEmployeesRepository
    {
        public UpSkillingEmployeesRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
