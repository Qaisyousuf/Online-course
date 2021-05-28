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
    public class ITGapSkillsSectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public ITGapSkillsSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetITGapSkillsSection()
        {
            var itSkillGapSection = uow.ITGapSkillsSectionRepository.GetAll();

            List<ITSkillGapSectionViewModel> viewmodel = new List<ITSkillGapSectionViewModel>();

            foreach (var item in itSkillGapSection)
            {
                viewmodel.Add(new ITSkillGapSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Subcontent=item.Subcontent,
                    AnimationUrl=item.AnimationUrl,
                    Button=item.Button,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ITSkillGapSectionViewModel());
        }

        [HttpPost]
        public ActionResult Create(ITSkillGapSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var itSkillsGapSection = new ITSkillGapSection
                {
                    Id = viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Subcontent=viewmodel.Subcontent,
                    AnimationUrl=viewmodel.AnimationUrl,
                    Button=viewmodel.Button,
                    ButtonUrl=viewmodel.ButtonUrl,
                };

                uow.ITGapSkillsSectionRepository.Add(itSkillsGapSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var itSkillsGapSection = uow.ITGapSkillsSectionRepository.GetById(id);

            ITSkillGapSectionViewModel viewmodel = new ITSkillGapSectionViewModel
            {
                Id=itSkillsGapSection.Id,
                MainTitle=itSkillsGapSection.MainTitle,
                Subcontent=itSkillsGapSection.Subcontent,
                AnimationUrl=itSkillsGapSection.AnimationUrl,
                Button=itSkillsGapSection.Button,
                ButtonUrl=itSkillsGapSection.ButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ITSkillGapSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var itSkillsGapSection = uow.ITGapSkillsSectionRepository.GetById(viewmodel.Id);

                itSkillsGapSection.Id = viewmodel.Id;
                itSkillsGapSection.MainTitle = viewmodel.MainTitle;
                itSkillsGapSection.Subcontent = viewmodel.Subcontent;
                itSkillsGapSection.AnimationUrl = viewmodel.AnimationUrl;
                itSkillsGapSection.Button = viewmodel.Button;
                itSkillsGapSection.ButtonUrl = viewmodel.ButtonUrl;

                uow.ITGapSkillsSectionRepository.Update(itSkillsGapSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var itSkillsGapSection = uow.ITGapSkillsSectionRepository.GetById(id);

            ITSkillGapSectionViewModel viewmodel = new ITSkillGapSectionViewModel
            {
                Id = itSkillsGapSection.Id,
                MainTitle = itSkillsGapSection.MainTitle,
                Subcontent = itSkillsGapSection.Subcontent,
                AnimationUrl = itSkillsGapSection.AnimationUrl,
                Button = itSkillsGapSection.Button,
                ButtonUrl = itSkillsGapSection.ButtonUrl,
            };
            uow.ITGapSkillsSectionRepository.Remove(itSkillsGapSection);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var itSkillsGapSection = uow.ITGapSkillsSectionRepository.GetById(id);

            ITSkillGapSectionViewModel viewmodel = new ITSkillGapSectionViewModel
            {
                Id = itSkillsGapSection.Id,
                MainTitle = itSkillsGapSection.MainTitle,
                Subcontent = itSkillsGapSection.Subcontent,
                AnimationUrl = itSkillsGapSection.AnimationUrl,
                Button = itSkillsGapSection.Button,
                ButtonUrl = itSkillsGapSection.ButtonUrl,
            };

            return View(viewmodel);
        }
    }
}