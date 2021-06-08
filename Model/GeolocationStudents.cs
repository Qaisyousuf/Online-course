using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class GeolocationStudents:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
       
        public string ProgramName { get; set; }
        public string CountryFlag { get; set; }


        
        [Display(Name="Country Name")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryName CountryName { get; set; }



    }
}
