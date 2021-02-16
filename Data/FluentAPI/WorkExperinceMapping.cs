using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace Data.FluentAPI
{
    public class WorkExperinceMapping:EntityTypeConfiguration<WorkExperience>
    {
        public WorkExperinceMapping()
        {
            HasMany(t => t.WorkExperTags)
                .WithMany(w => w.WorkExperiences)
                .Map(WT =>
                {

                    WT.MapLeftKey("WorkExperinceTagsId");
                    WT.MapRightKey("WorkExperinceId");
                    WT.ToTable("WorkExperinceAndTags");

                });
           
        }
    }
}
