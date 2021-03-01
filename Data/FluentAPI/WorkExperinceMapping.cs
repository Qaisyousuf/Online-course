using Model;
using System.Data.Entity.ModelConfiguration;

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
