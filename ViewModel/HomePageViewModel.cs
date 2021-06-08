using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class HomePageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string Slug { get; set; }

        [Display(Name = "Home Banner Id")]
        public int HomeBannerId { get; set; }

        [ForeignKey("HomeBannerId")]
        public HomeBanner HomeBanner { get; set; }

        [Display(Name = "Home Banner Exploration Id")]
        public int HomeExplorationBannerId { get; set; }

        [ForeignKey("HomeExplorationBannerId")]
        public HomeExplorationBanner HomeExplorationBanner { get; set; }
    }
}
