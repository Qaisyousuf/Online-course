using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class UserBenefitsSectionController : Controller
    {
        private readonly IUnitOfWork uow;
        public UserBenefitsSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserBenefitsSectionData()
        {
            var userBenefitsSection = uow.UserBenefitsSectionRepository.GetAll();

            List<UserBenefitsSectionViewModel> viewmodel = new List<UserBenefitsSectionViewModel>();

            foreach (var item in userBenefitsSection)
            {
                viewmodel.Add(new UserBenefitsSectionViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    IconUrl = item.IconUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserBenefitsSectionViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserBenefitsSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userBenefitsSection = new UserBenefitsSection
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    IconUrl=viewmodel.IconUrl,
                };
                uow.UserBenefitsSectionRepository.Add(userBenefitsSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userBenefitsSection = uow.UserBenefitsSectionRepository.GetById(id);

            UserBenefitsSectionViewModel viewmodel = new UserBenefitsSectionViewModel
            {
                Id=userBenefitsSection.Id,
                MainTitle=userBenefitsSection.MainTitle,
                IconUrl=userBenefitsSection.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserBenefitsSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userBenefitsSection = uow.UserBenefitsSectionRepository.GetById(viewmodel.Id);

                userBenefitsSection.Id = viewmodel.Id;
                userBenefitsSection.MainTitle = viewmodel.MainTitle;
                userBenefitsSection.IconUrl = viewmodel.IconUrl;

                uow.UserBenefitsSectionRepository.Update(userBenefitsSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userBenefitsSection = uow.UserBenefitsSectionRepository.GetById(id);

            UserBenefitsSectionViewModel viewmodel = new UserBenefitsSectionViewModel
            {
                Id=userBenefitsSection.Id,
                MainTitle=userBenefitsSection.MainTitle,
                IconUrl=userBenefitsSection.IconUrl,
            };
            uow.UserBenefitsSectionRepository.Remove(userBenefitsSection);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userBenefitsSection = uow.UserBenefitsSectionRepository.GetById(id);

            UserBenefitsSectionViewModel viewmodel = new UserBenefitsSectionViewModel
            {
                Id = userBenefitsSection.Id,
                MainTitle = userBenefitsSection.MainTitle,
                IconUrl = userBenefitsSection.IconUrl,
            };

            return View(viewmodel);
        }
    }
}