using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class EmployeesNumbersRepository:Repository<Emplyees>,IEmployeesNumbersRepository
    {
        public EmployeesNumbersRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
