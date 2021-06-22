using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class ListOfViewModels:BaseViewModel
    {
        public List<CourseContentsViewModel> ListofCourseContentExploratoin { get; set; }
        public List<CourseEachSectionViewModel> ListCourseEachSection { get; set; }
    }
}
