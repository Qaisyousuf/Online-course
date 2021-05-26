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
    public class WhyYouNeedUpSkillingYourTeamSectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public WhyYouNeedUpSkillingYourTeamSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWhyYouNeedUpSkillingYourTeamSectionData()
        {
            var whyYouNeedUpSkillingYourTeamSection = uow.WhyYouNeedUpSkillingYourTeamSection.GetAll();

            List<WhyYouNeedUpSkillingTeamSectionViewModel> viewmodel = new List<WhyYouNeedUpSkillingTeamSectionViewModel>();

            foreach (var item in whyYouNeedUpSkillingYourTeamSection)
            {
                viewmodel.Add(new WhyYouNeedUpSkillingTeamSectionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    IconUrl=item.IconUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhyYouNeedUpSkillingTeamSectionViewModel());
        }
        
        [HttpPost]
        public ActionResult Create(WhyYouNeedUpSkillingTeamSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyYouNeedUpskillingYourTeamSection = new WhyYouNeedUpSkillingYourTeamSection
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    IconUrl=viewmodel.IconUrl,
                };

                uow.WhyYouNeedUpSkillingYourTeamSection.Add(whyYouNeedUpskillingYourTeamSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whyYouNeedUpSkillingYourTeamSection = uow.WhyYouNeedUpSkillingYourTeamSection.GetById(id);

            WhyYouNeedUpSkillingTeamSectionViewModel viewmodel = new WhyYouNeedUpSkillingTeamSectionViewModel
            {
                Id=whyYouNeedUpSkillingYourTeamSection.Id,
                Title=whyYouNeedUpSkillingYourTeamSection.Title,
                IconUrl=whyYouNeedUpSkillingYourTeamSection.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhyYouNeedUpSkillingTeamSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyYouNeedUpSkillingYourTeamSection = uow.WhyYouNeedUpSkillingYourTeamSection.GetById(viewmodel.Id);

                whyYouNeedUpSkillingYourTeamSection.Id = viewmodel.Id;
                whyYouNeedUpSkillingYourTeamSection.Title = viewmodel.Title;
                whyYouNeedUpSkillingYourTeamSection.IconUrl = viewmodel.IconUrl;

                uow.WhyYouNeedUpSkillingYourTeamSection.Update(whyYouNeedUpSkillingYourTeamSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var whyYouNeedUpSkillingYourTeamSection = uow.WhyYouNeedUpSkillingYourTeamSection.GetById(id);

            WhyYouNeedUpSkillingTeamSectionViewModel viewmodel = new WhyYouNeedUpSkillingTeamSectionViewModel
            {
                Id = whyYouNeedUpSkillingYourTeamSection.Id,
                Title = whyYouNeedUpSkillingYourTeamSection.Title,
                IconUrl = whyYouNeedUpSkillingYourTeamSection.IconUrl,
            };

            uow.WhyYouNeedUpSkillingYourTeamSection.Remove(whyYouNeedUpSkillingYourTeamSection);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var whyYouNeedUpSkillingYourTeamSection = uow.WhyYouNeedUpSkillingYourTeamSection.GetById(id);

            WhyYouNeedUpSkillingTeamSectionViewModel viewmodel = new WhyYouNeedUpSkillingTeamSectionViewModel
            {
                Id = whyYouNeedUpSkillingYourTeamSection.Id,
                Title = whyYouNeedUpSkillingYourTeamSection.Title,
                IconUrl = whyYouNeedUpSkillingYourTeamSection.IconUrl,
            };

            return View(viewmodel);
        }
    }
}