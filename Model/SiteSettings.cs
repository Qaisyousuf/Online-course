using System;
using System.Collections.Generic;

namespace Model
{
    public class SiteSettings:EntityBase
    {
        public SiteSettings()
        {
            FotterLinks = new List<FooterLinks>();
        }
        public string SiteName { get; set; }
        public string SiteOwner { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string GoogleAnalytics { get; set; }
        public DateTime SiteLastUpdatedDate { get; set; }

        public string AnimationUrl { get; set; }

        public List<FooterLinks> FotterLinks { get; set; }
    }
}
