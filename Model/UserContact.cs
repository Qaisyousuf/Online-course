using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserContact:EntityBase
    {
        public string Name { get; set; }

        public string Message { get; set; }
        public string ContactBy { get; set; }
        public string ContactEmail { get; set; }

        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }

       
    }
}
