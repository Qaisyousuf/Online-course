﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel
{
   public class BaseViewModel
    {
        public BaseViewModel()
        {
            FooterLinks = new List<FooterLinks>();
        }

        [Display(Name = "Site title")]
        public string SiteTitle { get; set; }

       
        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

       
        [Display(Name = "Site Owner")]
        public string SiteOwner { get; set; }

        [Display(Name = "Google site verification")]
        public string GoogleSiteVerification { get; set; }

        [Display(Name = "Google Analytics")]
        public string GoogleAnalytics { get; set; }


        public DateTime SiteLastUpdatedDate { get; set; }


        [Display(Name = "Footer Links")]
        public int[] FooterLinksId { get; set; }

        public List<string> FooterLinksTag { get; set; }


        [Display(Name = "Animation Url")]
       
        public string AnimationUrl { get; set; }

       
        [AllowHtml]
        [Display(Name = "site Content")]
        public string SiteContent { get; set; }

        
        [Display(Name = "Designed by")]
        public string DesignedBy { get; set; }

      
        [Display(Name = "Site Copyright")]
        public string Sitecopyright { get; set; }


       
        public List<FooterLinks> FooterLinks { get; set; }
    }
}
