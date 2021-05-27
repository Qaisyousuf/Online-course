using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class GeolocationStudentsRepository:Repository<GeolocationStudents>,IGeolocationStudentsRepository
    {
        public GeolocationStudentsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
