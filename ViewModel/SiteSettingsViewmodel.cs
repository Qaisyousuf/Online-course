using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class SiteSettingsViewmodel
    {
        public SiteSettingsViewmodel()
        {
            FooterLinks = new List<FooterLinks>();
        }
        public int Id { get; set; }
        public string SiteTitle { get; set; }
        public string SiteName { get; set; }
        public string SiteOwner { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string GoogleAnalytics { get; set; }
        public DateTime SiteLastUpdatedDate { get; set; }

        public string AnimationUrl { get; set; }

        public int FooterId { get; set; }

        [ForeignKey("FooterId")]
        public List<FooterLinks> FooterLinks { get; set; }
    }
}
