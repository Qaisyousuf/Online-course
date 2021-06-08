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
    public class BuildBetterSkillsFasterSecitonController : Controller
    {
        private readonly IUnitOfWork uow;

        public BuildBetterSkillsFasterSecitonController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBuildBetterSkillsFasterSectionData()
        {
            var buildBetterSkillsFasterSection = uow.BuildBetterSkillsFasterSectionRepository.GetAll();

            List<BuildBetterSkillsFasterSectionViewModel> viewmodel = new List<BuildBetterSkillsFasterSectionViewModel>();

            foreach (var item in buildBetterSkillsFasterSection)
            {
                viewmodel.Add(new BuildBetterSkillsFasterSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    IconUrl=item.IconUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BuildBetterSkillsFasterSectionViewModel());
        }

        [HttpPost]
        public ActionResult Create(BuildBetterSkillsFasterSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var buildBetterSkillsFasterSection = new BuildBetterSkillsFasterSection
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    IconUrl=viewmodel.IconUrl,
                    Content=viewmodel.Content,
                };

                uow.BuildBetterSkillsFasterSectionRepository.Add(buildBetterSkillsFasterSection);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var buildBetterSkillsFaster = uow.BuildBetterSkillsFasterSectionRepository.GetById(id);

            BuildBetterSkillsFasterSectionViewModel viewmodel = new BuildBetterSkillsFasterSectionViewModel
            {
                Id=buildBetterSkillsFaster.Id,
                MainTitle=buildBetterSkillsFaster.MainTitle,
                Content=buildBetterSkillsFaster.Content,
                IconUrl=buildBetterSkillsFaster.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(BuildBetterSkillsFasterSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var buildBetterSkillsFaster = uow.BuildBetterSkillsFasterSectionRepository.GetById(viewmodel.Id);

                buildBetterSkillsFaster.Id = viewmodel.Id;
                buildBetterSkillsFaster.MainTitle = viewmodel.MainTitle;
                buildBetterSkillsFaster.Content = viewmodel.Content;
                buildBetterSkillsFaster.IconUrl = viewmodel.IconUrl;

                uow.BuildBetterSkillsFasterSectionRepository.Update(buildBetterSkillsFaster);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var buildBetterSkillsFaster = uow.BuildBetterSkillsFasterSectionRepository.GetById(id);

            BuildBetterSkillsFasterSectionViewModel viewmodel = new BuildBetterSkillsFasterSectionViewModel
            {
                Id=buildBetterSkillsFaster.Id,
                MainTitle=buildBetterSkillsFaster.MainTitle,
                Content=buildBetterSkillsFaster.Content,
                IconUrl=buildBetterSkillsFaster.IconUrl,
            };
            uow.BuildBetterSkillsFasterSectionRepository.Remove(buildBetterSkillsFaster);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var buildBetterSkillsFaster = uow.BuildBetterSkillsFasterSectionRepository.GetById(id);

            BuildBetterSkillsFasterSectionViewModel viewmodel = new BuildBetterSkillsFasterSectionViewModel
            {
                Id = buildBetterSkillsFaster.Id,
                MainTitle = buildBetterSkillsFaster.MainTitle,
                Content = buildBetterSkillsFaster.Content,
                IconUrl = buildBetterSkillsFaster.IconUrl,
            };

            return View(viewmodel);
        }
    }
}