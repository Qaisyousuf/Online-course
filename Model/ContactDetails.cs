using System;

namespace Model
{
    public class ContactDetails:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime WorkingStartDate { get; set; }
        public DateTime WrokingEndDate { get; set; }
        public string Address { get; set; }

    }
}
