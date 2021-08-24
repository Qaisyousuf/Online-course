using Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class ClassDataViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        [Display(Name ="Class Name")]
        public string ClassName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Class Start Data")]
        public DateTime ClassStartData { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Class Start Time")]
        public DateTime ClassStartTime { get; set; }

        [Required]
        [Display(Name ="Total course days")]
        public string TotalCourseDays { get; set; }

        [Required]
        [Display(Name ="Course description")]
        public string ClassDescription { get; set; }

        [Display(Name ="Contacted By")]
        [Required]
        public string ContactedBy { get; set; }

        [Display(Name ="UserName")]
        public string UserName { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }
    }
}
