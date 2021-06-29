using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Controllers
{
    public class AboutController : BaseController
    {
       
        [Route("about-us")]
        public ActionResult Index(string slug)
        {
            var aboutPage = _uow.AboutPageRepository.GetAll();

            List<AboutPageViewModel> viewmodel = new List<AboutPageViewModel>();

            foreach (var item in aboutPage)
            {
                viewmodel.Add(new AboutPageViewModel
                {
                    Id=item.Id,
                    Slug=item.Slug,
                    Content=item.Content,
                    Title=item.Title,
                    BannerId=item.BannerId,
                    AboutBanners=item.AboutBanners,
                });

             
            }
           

            ListOfViewModels aboutPageData = new ListOfViewModels
            {
                ListofAboutPage=viewmodel
            };

            return View(aboutPageData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAboutBanner()
        {
            var aboutBanner = _uow.AboutBannerRepository.GetAll();

            List<AboutBannerViewModel> viewmodel = new List<AboutBannerViewModel>();

            foreach (var item in aboutBanner)
            {
                viewmodel.Add(new AboutBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonUrl=item.DiscoverButtonUrl,
                });
            }
            ListOfViewModels AboutBannerData = new ListOfViewModels
            {
                ListofAboutBanner=viewmodel
            };

            return PartialView(AboutBannerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOnlineTrainingBenefits()
        {
            var onlineTrainingBenefits = _uow.OnlinetrainingbenefitsRepository.GetAll();

            List<OnlinetrainingbenefitsViewModel> viewmodel = new List<OnlinetrainingbenefitsViewModel>();
            foreach (var item in onlineTrainingBenefits)
            {
                viewmodel.Add(new OnlinetrainingbenefitsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            ListOfViewModels OnlinTraningBenefitsData = new ListOfViewModels
            {
                ListofOnlinTrainingBenefits=viewmodel
            };

            return PartialView(OnlinTraningBenefitsData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserBenefitsContent()
        {
            var userBenefits = _uow.UserbenefitsContentsRepository.GetAll();

            List<UserbenefitsContentsViewModel> viewmodel = new List<UserbenefitsContentsViewModel>();

            foreach (var item in userBenefits)
            {
                viewmodel.Add(new UserbenefitsContentsViewModel
                {
                    Id=item.Id,
                    Maintitle=item.Maintitle,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    Content=item.Content,
                });
            }
            ListOfViewModels UserBenefitsContentData = new ListOfViewModels
            {
                ListOfUserBenefitsContent=viewmodel
            };

            return PartialView(UserBenefitsContentData);
        }
    }
}