using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class WorkExperienceViewModel:BaseViewModel
    {
        public WorkExperienceViewModel()
        {
            WorkExperTags = new List<WorkExperienceTags>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrlFooter { get; set; }

        

        [Display(Name ="Work Tags")]
        public int[] TagsId { get; set; }

        [Display(Name ="Tag Name")]
        public List<string> TagsNames { get; set; }

        public List<WorkExperienceTags> WorkExperTags { get; set; }
    }
}
