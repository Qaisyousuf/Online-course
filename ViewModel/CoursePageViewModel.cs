using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class CoursePageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name = "Banner")]
        public int CourseBannerId { get; set; }

        [ForeignKey("CourseBannerId")]
        public CourseBanner CourseBanner { get; set; }

    }
}
