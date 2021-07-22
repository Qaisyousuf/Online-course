using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class ForBusinessController : BaseController
    {
        [Route("Business")]
        public ActionResult Index(string slug)
        {

            var business = _uow.BusinessPageRepository.GetAll();

            List<BusinessPageViewModel> PageViewModel = new List<BusinessPageViewModel>();

            foreach (var item in business)
            {
                PageViewModel.Add(new BusinessPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    BusinessBanner=item.BusinessBanner,
                    BusinessBannerId=item.BusinessBannerId,
                    
                });
                ViewBag.PagetTitle = item.Title;
            }

            ListOfViewModels BusinessPageData = new ListOfViewModels
            {
                ListofBusinessPage=PageViewModel,
            };
            return View(BusinessPageData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetBusinessBanner()
        {
            var businessBanner = _uow.BusinessBannerRepository.GetAll();

            List<BusinessBannerViewModel> businessviewmodel = new List<BusinessBannerViewModel>();

            foreach (var item in businessBanner)
            {
                businessviewmodel.Add(new BusinessBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    SubContent=item.SubContent,
                    JoinButton=item.JoinButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                    DiscoverButton=item.DiscoverButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                });
            }

            ListOfViewModels GetBusinessBannerData = new ListOfViewModels
            {
                ListofBusinessBannerViewMoodel=businessviewmodel,
            };

            return PartialView(GetBusinessBannerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTrustedBy()
        {
            var trustedby = _uow.TrustedbyForUpSkillingRepository.GetAll();

            List<TrustedbyForUpSkillingViewModel> TrustedViewModel = new List<TrustedbyForUpSkillingViewModel>();

            foreach (var item in trustedby)
            {
                TrustedViewModel.Add(new TrustedbyForUpSkillingViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    AnimationUrl=item.AnimationUrl,
                    LogoUrl=item.LogoUrl,
                });
            }

            ListOfViewModels TrustedByData = new ListOfViewModels
            {
                ListofTrustedByviewModel=TrustedViewModel,
            };

            return PartialView(TrustedByData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUpSkillingExploration()
        {
            var upSkillingExploration = _uow.UpskillingExplorationRepository.GetAll();
            List<UpskillingExplorationViewModel> viewmodel = new List<UpskillingExplorationViewModel>();

            foreach (var item in upSkillingExploration)
            {
                viewmodel.Add(new UpskillingExplorationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    AnimationUrl=item.AnimationUrl,
                    Content=item.Content,
                    IconUlr=item.IconUlr,
                });
            }

            ListOfViewModels UpskillingExplorationData = new ListOfViewModels
            {
                ListOfUpSkillingExploration=viewmodel,
            };

            return PartialView(UpskillingExplorationData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ImportanceofUpSkilling()
        {
            var importanceofUpskilling = _uow.UpskillingImportanceRepository.GetAll();

            List<UpskillingImportanceViewModel> viewmodel = new List<UpskillingImportanceViewModel>();

            foreach (var item in importanceofUpskilling)
            {
                viewmodel.Add(new UpskillingImportanceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Animation=item.Animation,
                    RegisterButtonUrl=item.RegisterButtonUrl,
                    RegisterButton=item.RegisterButton,
                    ContactButton=item.ContactButton,
                    ContactButtonUrl=item.ContactButtonUrl,
                });
            }

            ListOfViewModels ImportanceOfUuSkillingData = new ListOfViewModels
            {
                ListOfImportanceOfUpSkilling=viewmodel,
            };

            return PartialView(ImportanceOfUuSkillingData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult UpSkillingTeam()
        {
            var upSkillingTeam = _uow.WhyYouNeedUpskillingYourTeamRepository.GetAll();

            List<WhyYouNeedUpskillingYourTeamViewModel> viewmodel = new List<WhyYouNeedUpskillingYourTeamViewModel>();

            foreach (var item in upSkillingTeam)
            {
                viewmodel.Add(new WhyYouNeedUpskillingYourTeamViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    AnimationUrl=item.AnimationUrl,
                    Content=item.Content,

                });
            }


            var upskillingSection = _uow.WhyYouNeedUpSkillingYourTeamSection.GetAll();

            List<WhyYouNeedUpSkillingTeamSectionViewModel> UpSkillingSectionViewmodel = new List<WhyYouNeedUpSkillingTeamSectionViewModel>();

            foreach (var item in upskillingSection)
            {
                UpSkillingSectionViewmodel.Add(new WhyYouNeedUpSkillingTeamSectionViewModel
                {
                    Id=item.Id,
                    IconUrl=item.IconUrl,
                    Title=item.Title,
                });
            }
            ListOfViewModels UpSkillingYourTeamData = new ListOfViewModels
            {
                ListOfUpSkillingYourTeam=viewmodel,
                ListOfUpSkillingSection=UpSkillingSectionViewmodel,
            };
            return PartialView(UpSkillingYourTeamData);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult EmployeeUpSkilling()
        {
            var employeeUpSkilling = _uow.UpSkillingEmployeesRepository.GetAll();

            List<UpskillingEmployeeViewModel> viewmodel = new List<UpskillingEmployeeViewModel>();

            foreach (var item in employeeUpSkilling)
            {
                viewmodel.Add(new UpskillingEmployeeViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    TalkToExpertButton=item.TalkToExpertButton,
                    TalkToExpertButtonUrl=item.TalkToExpertButtonUrl,
                    IllstrationUrl=item.IllstrationUrl,
                });
            }

            ListOfViewModels EmployeeUpskillingData = new ListOfViewModels
            {
                ListofUpskillingEmployee=viewmodel,
            };

            return PartialView(EmployeeUpskillingData);
        }
    }
}