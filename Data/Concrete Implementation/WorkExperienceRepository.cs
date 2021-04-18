using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class WorkExperienceRepository:Repository<WorkExperience>,IWorkExperienceRepository
    {
        public WorkExperienceRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
