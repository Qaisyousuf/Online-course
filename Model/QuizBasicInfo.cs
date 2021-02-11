using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class QuizBasicInfo:EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public CountryName CountryNames { get; set; }
    }
}
