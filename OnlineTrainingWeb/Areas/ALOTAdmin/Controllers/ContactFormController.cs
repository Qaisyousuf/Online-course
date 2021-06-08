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
    public class ContactFormController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactFormController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            GetContactFormData();
            return View();
        }

        private void GetCountryName()
        {
            ViewBag.Country = uow.CountryNamesRepository.GetAll();
            ViewBag.EmployeesNumber = uow.EmployeesNumbersRepository.GetAll();
            
        }

        [HttpGet]
        public ActionResult GetContactFormData()
        {
            var contactForm = uow.ContactFormRepository.GetAll("CountryNames", "Emplyees");

            List<ContactFormViewModel> viewmodel = new List<ContactFormViewModel>();

            foreach (var item in contactForm)
            {
                viewmodel.Add(new ContactFormViewModel
                {
                    Id=item.Id,
                    FullName=item.FullName,
                    Email=item.Email,
                    PhoneNumber=item.PhoneNumber,
                    JobTitle=item.JobTitle,
                    Message=item.Message,
                    EmployeeId=item.EmployeeId,
                    Emplyees=item.Emplyees,
                    CountryId=item.CountryId,
                    CountryNames=item.CountryNames,
                });
            }

           
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactForm = uow.ContactFormRepository.GetById(id);

            ContactFormViewModel viewmodel = new ContactFormViewModel
            {
                FullName=contactForm.FullName,
                Id=contactForm.Id,
                Email=contactForm.Email,
                PhoneNumber=contactForm.PhoneNumber,
                JobTitle=contactForm.JobTitle,
                Message=contactForm.Message,
                EmployeeId=contactForm.EmployeeId,
                Emplyees=contactForm.Emplyees,
                CountryNames=contactForm.CountryNames,
                CountryId=contactForm.CountryId,
            };

            uow.ContactFormRepository.Remove(contactForm);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactForm = uow.ContactFormRepository.GetById(id);

            ContactFormViewModel viewmodel = new ContactFormViewModel
            {
                Id = contactForm.Id,
                FullName = contactForm.FullName,
                Email = contactForm.Email,
                PhoneNumber = contactForm.PhoneNumber,
                JobTitle = contactForm.JobTitle,
                Message = contactForm.Message,
                EmployeeId = contactForm.EmployeeId,
                Emplyees = contactForm.Emplyees,
                CountryNames = contactForm.CountryNames,
                CountryId = contactForm.CountryId,
            };
            GetContactFormData();
            return View(viewmodel);
        }
    }
}