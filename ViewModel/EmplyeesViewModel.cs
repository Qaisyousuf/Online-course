using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class EmplyeesViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Number of employees")]
        public string NumberOfEmployee { get; set; }
    }
}
