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
    public class WorkExperienceTagController : Controller
    {
        private readonly IUnitOfWork uow;

        public WorkExperienceTagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWorkExperienceTagData()
        {
            var workExperienceTag = uow.WorkExperienceTagsRepository.GetAll();

            List<WorkExperienceTagsViewModel> viewmodel = new List<WorkExperienceTagsViewModel>();

            foreach (var item in workExperienceTag)
            {
                viewmodel.Add(new WorkExperienceTagsViewModel
                {
                    Id=item.Id,
                    TagsName=item.TagsName,
                   
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WorkExperienceTagsViewModel());
        }

        [HttpPost]
        public ActionResult Create(WorkExperienceTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var workExperinceTag = new WorkExperienceTags
                {
                    Id=viewmodel.Id,
                    TagsName=viewmodel.TagsName,
                };

                uow.WorkExperienceTagsRepository.Add(workExperinceTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var workExperienceTag = uow.WorkExperienceTagsRepository.GetById(id);

            WorkExperienceTagsViewModel viewmodel = new WorkExperienceTagsViewModel
            {
                Id=workExperienceTag.Id,
                TagsName=workExperienceTag.TagsName,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WorkExperienceTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var workExperienceTags = uow.WorkExperienceTagsRepository.GetById(viewmodel.Id);

                workExperienceTags.Id = viewmodel.Id;
                workExperienceTags.TagsName = viewmodel.TagsName;

                uow.WorkExperienceTagsRepository.Update(workExperienceTags);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var workExperienceTag = uow.WorkExperienceTagsRepository.GetById(id);

            WorkExperienceTagsViewModel viewmodel = new WorkExperienceTagsViewModel
            {
                Id=workExperienceTag.Id,
                TagsName=workExperienceTag.TagsName,
            };
            uow.WorkExperienceTagsRepository.Remove(workExperienceTag);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var workExperienceTag = uow.WorkExperienceTagsRepository.GetById(id);

            WorkExperienceTagsViewModel viewmodel = new WorkExperienceTagsViewModel
            {
                Id = workExperienceTag.Id,
                TagsName = workExperienceTag.TagsName,
            };
            return View(viewmodel);
        }
    }
}