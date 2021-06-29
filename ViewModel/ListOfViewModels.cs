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
        public List<ForLearnerViewModel> ListOfForLearner { get; set; }
        public List<OurVisionViewModel> ListOfOurVision { get; set; }
        public List<COVID_19ViewModel> ListOfCovid { get; set; }
        public List<MetaTagViewModel> ListofMetaTag { get; set; }
        public List<OpenGraphMetaTagsViewModel> ListofOGTag { get; set; }
        public List<TwitterMetaTagsViewModel> ListofTwitterTag { get; set; }
        public List<QuizContentViewModel> ListofQuizContnet { get; set; }
        public List<AboutPageViewModel> ListofAboutPage { get; set; }
        public List<AboutBannerViewModel> ListofAboutBanner { get; set; }
        public List<OnlinetrainingbenefitsViewModel> ListofOnlinTrainingBenefits { get; set; }
        public List<UserbenefitsContentsViewModel> ListOfUserBenefitsContent { get; set; }

    }
}
