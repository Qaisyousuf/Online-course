using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class UpSkillingEmployeesRepository:Repository<UpskillingEmployee>,IUpSkillingEmployeesRepository
    {
        public UpSkillingEmployeesRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
