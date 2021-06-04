using Model;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class SiteSettingsViewmodel
    {
        public SiteSettingsViewmodel()
        {
            FooterLinks = new List<FooterLinks>();
        }
        public string SiteName { get; set; }
        public string SiteOwner { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string GoogleAnalytics { get; set; }
        public DateTime SiteLastUpdatedDate { get; set; }

        public string AnimationUrl { get; set; }

        public List<FooterLinks> FooterLinks { get; set; }
    }
}
