using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class SubscriptionSystemViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Your Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
