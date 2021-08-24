using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ClassData:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ClassName { get; set; }
        public DateTime ClassStartData { get; set; }
        public string TotalCourseDays { get; set; }
        
        public string ClassDescription { get; set; }
        public string contactedBy { get; set; }
        public string UserName { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }




    }
}
