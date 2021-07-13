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
        //[Route("Contact")]
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
                    Address=item.Address,
                    WorkingStartDate=DateOfWeek,
                    WorkingStartTime=TimeOfWeek,
                    EndTime=time,
                    WrokingEndDate=date,
                    MapAnimationUrl=item.MapAnimationUrl,
                    
                });
            }

            var socialMedia = _uow.TrainerSocialMediaRepository.GetAll();

            List<TrainerSocialMediaViewModel> socialMediaViewModel = new List<TrainerSocialMediaViewModel>();

            foreach (var item in socialMedia)
            {
                socialMediaViewModel.Add(new TrainerSocialMediaViewModel
                {
                    Id=item.Id,
                    SocialMediaProfileUrl=item.SocialMediaProfileUrl,
                    SocialMediaIconUrl=item.SocialMediaIconUrl,
                });
            }

            ListOfViewModels ContactDetailsData = new ListOfViewModels
            {
                ListofContactDetails=viewmodel,
                ListOfTrainerSocialMedia=socialMediaViewModel,
            };

            return PartialView(ContactDetailsData);

        }

        private void GetContactFormData()
        {
            ViewBag.CountryName = _uow.CountryNamesRepository.GetAll();
            ViewBag.Employees = _uow.EmployeesNumbersRepository.GetAll();
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult ContactForm()
        {
            GetContactFormData();
            return View(new ContactFormViewModel());
        }
        [HttpPost]
        [Route("Contact")]
        public ActionResult ContactForm(ContactFormViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {

                var contactform = new ContactForm
                {
                    Id=viewmodel.Id,
                    FullName=viewmodel.FullName,
                    Email=viewmodel.Email,
                    PhoneNumber=viewmodel.PhoneNumber,
                    JobTitle=viewmodel.JobTitle,
                    Message=viewmodel.Message,
                    EmployeeId=viewmodel.EmployeeId,
                    Emplyees=viewmodel.Emplyees,
                    CountryId=viewmodel.CountryId,
                    CountryNames=viewmodel.CountryNames,
                };

                _uow.ContactFormRepository.Add(contactform);
                _uow.Commit();
                return Json(new { success = true, message = "Thank You! "+contactform.FullName+" for contacting us" }, JsonRequestBehavior.AllowGet);

            }
            
            return RedirectToAction("ThankYou");
        }

        //[HttpGet]
        //[Route("GeoLocation")]
        //public ActionResult ThankYou()
        //{
        //    return View();
        //}

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetGeoLocaiton()
        {

            var geoLocation = _uow.GeolocationStudentsRepository.GetAll("CountryName");

           
            ViewBag.CountryName = _uow.CountryNamesRepository.GetAll();
            List<GeolocationStudentsViewModel> geoLocationViewModel = new List<GeolocationStudentsViewModel>();

            foreach (var item in geoLocation)
            {
                var countryName = item.CountryName;
                geoLocationViewModel.Add(new GeolocationStudentsViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Title = item.Title,
                    Name = item.Name,
                    ProgramName = item.ProgramName,
                    CountryFlag = item.CountryFlag,
                    CountryId = item.CountryId,
                    CountryName = countryName,
                });
            }

            ListOfViewModels GetGeoLocationData = new ListOfViewModels
            {
                ListOfGeoLocation=geoLocationViewModel
            };

            return PartialView(GetGeoLocationData);
        }

        [Route("Contact")]
        [HttpGet]
        public ActionResult GetNewsLetter(string slug)
        {
            return View(new SubscriptionSystemViewModel());
        }
        [Route("Contact")]
        [HttpPost]
        public ActionResult GetNewsLetter(SubscriptionSystemViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var EmailExists = _uow.Context.SubscriptionSystems.Any(x => x.Email == viewmodel.Email);

                if (EmailExists)
                {
                    return Json(new { error = true, message = "Email already exists" }, JsonRequestBehavior.AllowGet);
                }

                var subscription = new SubscriptionSystem
                {
                    UserName = viewmodel.UserName,
                    Email = viewmodel.Email,
                };

                _uow.SubscriptionSystemRepository.Add(subscription);
                _uow.Commit();


            }

            return Json(new { success = true, message = "Thanks for subscribing" }, JsonRequestBehavior.AllowGet);

        }

    }
}