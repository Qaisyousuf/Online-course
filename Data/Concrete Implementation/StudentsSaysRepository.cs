using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class StudentsSaysRepository:Repository<StudentsSay>,IStudentsSaysRepository
    {
        public StudentsSaysRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
