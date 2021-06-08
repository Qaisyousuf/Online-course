using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Models;

namespace Data.FluentAPI
{
    public class SiteSettingMapping:EntityTypeConfiguration<SiteSettings>
    {
        public SiteSettingMapping()
        {
            HasMany(x => x.FotterLinks)
                .WithMany(s => s.SiteSettings)
                .Map(xs =>
                {
                    xs.MapLeftKey("FooterLinksId");
                    xs.MapRightKey("SiteSettingsId");
                    xs.ToTable("SiteSettingsFooterLinks");
                });
        }
    }
}
