using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Controllers
{
    public class ContactController : BaseController
    {
        [Route("Contact")]
        public ActionResult Index(string slug)
        {

            var contactPage = _uow.ContactpageRepository.GetAll();

            List<ContactPageViewModel> viewmodel = new List<ContactPageViewModel>();

            foreach (var item in contactPage)
            {
                viewmodel.Add(new ContactPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    ContactBannerId=item.ContactBannerId,
                    ContactBanners=item.ContactBanners,
                });
            }

            ListOfViewModels ContactPageData = new ListOfViewModels
            {
                ListofContactpage=viewmodel,
            };
            return View(ContactPageData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ContactBanner()
        {
            var contactBanner = _uow.ContactBannerRepository.GetAll();

            List<ContactBannerViewModel> viewmodel = new List<ContactBannerViewModel>();

            foreach (var item in contactBanner)
            {
                viewmodel.Add(new ContactBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubContent=item.SubContent,
                    ImageUrl=item.ImageUrl,
                    Content=item.Content,
                    SubTitle=item.SubTitle,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                });
            }

            ListOfViewModels ContactBannerData = new ListOfViewModels
            {
                ListofContactBanner=viewmodel,
            };
            return PartialView(ContactBannerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ContactDetails()
        {
            var contactDetails = _uow.ContactDetailsRepository.GetAll();

            List<ContactDetailsViewModel> viewmodel = new List<ContactDetailsViewModel>();

            foreach (var item in contactDetails)
            {


                var datatime = item.WorkingStartDate;
                var dateTimeOfWeek = item.WrokingEndDate;

                var TimeOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortTimeString());
                var DateOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortDateString());
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());

               
                viewmodel.Add(new ContactDetailsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    MobileNumber=item.MobileNumber,
                    Email=item.Email,
                    WorkingStartDate=DateOfWeek,
                    WorkingStartTime=TimeOfWeek,
                    EndTime=time,
                    WrokingEndDate=date,
                    
                });
            }

            ListOfViewModels ContactDetailsData = new ListOfViewModels
            {
                ListofContactDetails=viewmodel,
            };

            return PartialView(ContactDetailsData);

        }
    }
}