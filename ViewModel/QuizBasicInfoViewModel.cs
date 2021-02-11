using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ViewModel
{
    public class QuizBasicInfoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Mobile Optional")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public CountryName CountryNames { get; set; }
    }
}
