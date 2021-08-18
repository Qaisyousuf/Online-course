using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    [HandleError]
    public class QuizPageFrontController : BaseController
    {
       
        public ActionResult Index(string slug)
        {
            var quizPage = _uow.QuizPageRepository.GetAll("QuizBanners");

            List<QuizPageViewModel> viewmodel = new List<QuizPageViewModel>();

            foreach (var item in quizPage)
            {
                viewmodel.Add(new QuizPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    QuizBannerId=item.QuizBannerId,
                    QuizBanners=item.QuizBanners,
                });
            }

            ListOfViewModels GetQuizPageData = new ListOfViewModels
            {
                ListOfQuizPage=viewmodel,
            };
            return View(GetQuizPageData);
        }

        [HttpGet]
        [ChildActionOnly]
       
        public ActionResult QuizBanner()
        {
            var quizBanner = _uow.QuizBannerRepository.GetAll();
            List<QuizBannerViewModel> viewmodel = new List<QuizBannerViewModel>();

            foreach (var item in quizBanner)
            {
                viewmodel.Add(new QuizBannerViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    JoinButton = item.JoinButton,
                    JoinButtonUrl = item.JoinButtonUrl,
                    DiscoverButton = item.DiscoverButton,
                    DiscoverButtonTUrl = item.DiscoverButtonTUrl,
                });
            }
            ListOfViewModels GetQuizBannerData = new ListOfViewModels
            {
                ListofQuizBanner = viewmodel,
            };

            return PartialView(GetQuizBannerData);
        }

        [HttpGet]
        [Route("StartQuiz")]
        public ActionResult QuizBasicInfoContact()
        {
            ViewBag.CountryName = _uow.CountryNamesRepository.GetAll();
            return View(new QuizBasicInfoViewModel());
        }
        [HttpPost]
        [Route("StartQuiz")]
        public ActionResult QuizBasicInfoContact(QuizBasicInfoViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizBasicInfo = new QuizBasicInfo
                {
                    Id=viewmodel.Id,
                    FullName=viewmodel.FullName,
                    Email=viewmodel.Email,
                    Mobile=viewmodel.Mobile,
                    CountryId=viewmodel.CountryId,
                    CountryNames=viewmodel.CountryNames,
                };
                ViewBag.CountryName = _uow.CountryNamesRepository.GetAll();
                _uow.QuizBasicInfoRepository.Add(quizBasicInfo);
                _uow.Commit();
                return Json(new { success = true, message = "Thank You! " + quizBasicInfo.FullName + " for contacting us" }, JsonRequestBehavior.AllowGet);

            }
            return RedirectToAction("RecomandedCourse");
        }

        [HttpGet]

        [Route("RecomandedCourse")]
        public ActionResult RecomandedCourse()
        {
            var coursesData = _uow.CourseDescriptionRepository.GetAll();

            ViewBag.Courses = coursesData;
            return View();
            
        }
  

    }
}