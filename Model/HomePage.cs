﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class HomePage:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string Slug { get; set; }

        [Display(Name ="Home Banner Id")]
        public int HomeBannerId { get; set; }

        [ForeignKey("HomeBannerId")]
        public HomeBanner HomeBanner { get; set; }

        [Display(Name = "Home Banner Exploration Id")]
        public int HomeExplorationBannerId { get; set; }

        [ForeignKey("HomeExplorationBannerId")]
        public HomeExplorationBanner HomeExplorationBanner { get; set; }



    }
}
