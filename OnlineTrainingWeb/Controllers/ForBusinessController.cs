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
    }
}