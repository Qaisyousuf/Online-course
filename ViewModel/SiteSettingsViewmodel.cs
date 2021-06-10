using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ViewModel
{
    public class SiteSettingsViewmodel
    {
        public SiteSettingsViewmodel()
        {
            FooterLinks = new List<FooterLinks>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Site title")]
        public string SiteTitle { get; set; }

        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

        [Required]
        [Display(Name ="Site Owner")]
        public string SiteOwner { get; set; }

        [Display(Name ="Google site verification")]
        public string GoogleSiteVerification { get; set; }

        [Display(Name ="Google Analytics")]
        public string GoogleAnalytics { get; set; }

        
        public DateTime SiteLastUpdatedDate { get; set; }


        [Display(Name ="Footer Links")]
        public int[] FooterLinksId { get; set; }

        public List<string> FooterLinksTag { get; set; }


        [Display(Name ="Animation Url")]
        [Required]
        public string AnimationUrl { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name ="site Content")]
        public string SiteContent { get; set; }

        [Required]
        [Display(Name ="Designed by")]
        public string DesignedBy { get; set; }

        [Required]
        [Display(Name ="Site Copyright")]
        public string Sitecopyright { get; set; }

        [Display(Name ="Footer Links")]
        public int FooterId { get; set; }

        [ForeignKey("FooterId")]
        public List<FooterLinks> FooterLinks { get; set; }
    }
}
