using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactDetailsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactDetailsData()
        {
            var contactDetails = uow.ContactDetailsRepository.GetAll();

            List<ContactDetailsViewModel> viewmodel = new List<ContactDetailsViewModel>();

            foreach (var item in contactDetails)
            {
                viewmodel.Add(new ContactDetailsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    MobileNumber=item.MobileNumber,
                    Email=item.Email,
                    WorkingStartDate=item.WorkingStartDate,
                    WrokingEndDate=item.WrokingEndDate,
                    Address=item.Address,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactDetailsViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var StartDateFromViewModel = Convert.ToDateTime(viewmodel.WorkingStartDate);
                var StartTimeFromViewModel = Convert.ToDateTime(viewmodel.WorkingStartTime);
                var StartDateStartTimeCombination = new DateTime(StartDateFromViewModel.Year, StartDateFromViewModel.Month, StartDateFromViewModel.Day, StartTimeFromViewModel.Hour, StartTimeFromViewModel.Minute, StartTimeFromViewModel.Second);

                var EndDateFromViewModel = Convert.ToDateTime(viewmodel.WrokingEndDate);
                var EndTimeFromViewModel = Convert.ToDateTime(viewmodel.EndTime);

                var EndDateEndTimeCombination = new DateTime(EndDateFromViewModel.Year, EndDateFromViewModel.Month, EndDateFromViewModel.Day, EndTimeFromViewModel.Hour, EndTimeFromViewModel.Minute, EndTimeFromViewModel.Second);

                var contactdetails = new ContactDetails
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Title = viewmodel.Title,
                    MobileNumber = viewmodel.MobileNumber,
                    Email = viewmodel.Email,
                    WorkingStartDate=StartDateStartTimeCombination,
                    WrokingEndDate =EndDateEndTimeCombination,
                    Address = viewmodel.Address,
                };

                uow.ContactDetailsRepository.Add(contactdetails);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactDetails = uow.ContactDetailsRepository.GetById(id);


            var StartDateModel =(contactDetails.WorkingStartDate).ToShortDateString();
            var StartTimeFromModel =(contactDetails.WorkingStartDate).ToShortTimeString();
            var EndDateModel =(contactDetails.WrokingEndDate).ToShortDateString();
            var EndTimeFromModel =(contactDetails.WrokingEndDate).ToShortTimeString();

            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id=contactDetails.Id,
                MainTitle=contactDetails.MainTitle,
                Title=contactDetails.Title,
                MobileNumber=contactDetails.MobileNumber,
                Email=contactDetails.Email,
                Address=contactDetails.Address,
                WorkingStartDate=Convert.ToDateTime(StartDateModel),
                WorkingStartTime=Convert.ToDateTime(StartTimeFromModel),
                WrokingEndDate=Convert.ToDateTime(EndDateModel),
                EndTime=Convert.ToDateTime(EndTimeFromModel),

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactDetailsViewModel viewmodel)
        {

            var StartDateFromViewModel = Convert.ToDateTime(viewmodel.WorkingStartDate);
            var StartTimeFromViewModel = Convert.ToDateTime(viewmodel.WorkingStartTime);
            var StartDateStartTimeCombination = new DateTime(StartDateFromViewModel.Year, StartDateFromViewModel.Month, StartDateFromViewModel.Day, StartTimeFromViewModel.Hour, StartTimeFromViewModel.Minute, StartTimeFromViewModel.Second);

            var EndDateFromViewModel = Convert.ToDateTime(viewmodel.WrokingEndDate);
            var EndTimeFromViewModel = Convert.ToDateTime(viewmodel.EndTime);

            var EndDateEndTimeCombination = new DateTime(EndDateFromViewModel.Year, EndDateFromViewModel.Month, EndDateFromViewModel.Day, EndTimeFromViewModel.Hour, EndTimeFromViewModel.Minute, EndTimeFromViewModel.Second);
            if (ModelState.IsValid)
            {
                var contactDetails = uow.ContactDetailsRepository.GetById(viewmodel.Id);

                contactDetails.Id = viewmodel.Id;
                contactDetails.MainTitle = viewmodel.MainTitle;
                contactDetails.Title = viewmodel.Title;
                contactDetails.MobileNumber = viewmodel.MobileNumber;
                contactDetails.Address = viewmodel.Address;
                contactDetails.Email = viewmodel.Email;

                contactDetails.WorkingStartDate = StartDateStartTimeCombination;
                contactDetails.WrokingEndDate = EndDateEndTimeCombination;

                uow.ContactDetailsRepository.Update(contactDetails);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactDetails = uow.ContactDetailsRepository.GetById(id);

            var StartDateModel = (contactDetails.WorkingStartDate).ToShortDateString();
            var StartTimeFromModel = (contactDetails.WorkingStartDate).ToShortTimeString();
            var EndDateModel = (contactDetails.WrokingEndDate).ToShortDateString();
            var EndTimeFromModel = (contactDetails.WrokingEndDate).ToShortTimeString();

            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id = contactDetails.Id,
                MainTitle = contactDetails.MainTitle,
                Title = contactDetails.Title,
                MobileNumber = contactDetails.MobileNumber,
                Email = contactDetails.Email,
                Address = contactDetails.Address,
                WorkingStartDate = Convert.ToDateTime(StartDateModel),
                WorkingStartTime = Convert.ToDateTime(StartTimeFromModel),
                WrokingEndDate = Convert.ToDateTime(EndDateModel),
                EndTime = Convert.ToDateTime(EndTimeFromModel),

            };

            uow.ContactDetailsRepository.Remove(contactDetails);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactDetails = uow.ContactDetailsRepository.GetById(id);


            var StartDateModel = (contactDetails.WorkingStartDate).ToShortDateString();
            var StartTimeFromModel = (contactDetails.WorkingStartDate).ToShortTimeString();
            var EndDateModel = (contactDetails.WrokingEndDate).ToShortDateString();
            var EndTimeFromModel = (contactDetails.WrokingEndDate).ToShortTimeString();

            ContactDetailsViewModel viewmodel = new ContactDetailsViewModel
            {
                Id = contactDetails.Id,
                MainTitle = contactDetails.MainTitle,
                Title = contactDetails.Title,
                MobileNumber = contactDetails.MobileNumber,
                Email = contactDetails.Email,
                Address = contactDetails.Address,
                WorkingStartDate = Convert.ToDateTime(StartDateModel),
                WorkingStartTime = Convert.ToDateTime(StartTimeFromModel),
                WrokingEndDate = Convert.ToDateTime(EndDateModel),
                EndTime = Convert.ToDateTime(EndTimeFromModel),

            };
            return View(viewmodel);
        }
    }
}