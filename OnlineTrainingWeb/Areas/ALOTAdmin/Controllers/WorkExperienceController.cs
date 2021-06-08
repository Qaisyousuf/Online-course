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
    public class WorkExperienceController : Controller
    {
        private readonly IUnitOfWork uow;

        public WorkExperienceController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            TagsData();
            return View();
        }
        private void TagsData()
        {
            ViewBag.TagsData = uow.WorkExperienceTagsRepository.GetAll();
        }
        [HttpGet]
        public ActionResult GetWorkExperienceData()
        {
            var workExperience = uow.WorkExperienceRepository.GetAll();

            List<WorkExperienceViewModel> viewmodel = new List<WorkExperienceViewModel>();

            foreach (var item in workExperience)
            {

                //var tagIds = item.WorkExperTags.Select(x => x.Id).ToList();

                //var tagName = uow.Context.WorkExperienceTags.Where(x => tagIds.Contains(x.Id)).Select(x => x.TagsName).ToList();
                viewmodel.Add(new WorkExperienceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    AnimationUrl=item.AnimationUrl,
                    WorkExperTags=item.WorkExperTags,
                    
                    
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TagsData();
            return View(new WorkExperienceViewModel());
        }

        [HttpPost]
        public ActionResult Create(WorkExperienceViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var workExperience = new WorkExperience
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    AnimationUrl=viewmodel.AnimationUrl,
                    WorkExperTags=viewmodel.WorkExperTags,
                };

                foreach (int tagId in viewmodel.TagsId)
                {
                    var tag = uow.WorkExperienceTagsRepository.GetById(tagId);
                    workExperience.WorkExperTags.Add(tag);
                }

                uow.WorkExperienceRepository.Add(workExperience);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var workExperience = uow.Context.WorkExperiences.Include("WorkExperTags").SingleOrDefault(x => x.Id == id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id=workExperience.Id,
                MainTitle=workExperience.MainTitle,
                Title=workExperience.Title,
                AnimationUrl=workExperience.AnimationUrl,
                Content=workExperience.Content,

            };

            int[] tagsId = workExperience.WorkExperTags.Select(x => x.Id).ToArray();
            viewmodel.TagsId = tagsId;

            TagsData();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,MainTitle,Title,Content,AnimationUrl")]WorkExperienceViewModel viewmodel,int[] tagsid)
        {
            if(ModelState.IsValid)
            {
                var workExperience = uow.Context.WorkExperiences.Include("WorkExperTags").SingleOrDefault(x => x.Id == viewmodel.Id);
                workExperience.Id = viewmodel.Id;
                workExperience.MainTitle = viewmodel.MainTitle;
                workExperience.Title = viewmodel.Title;
                workExperience.Content = viewmodel.Content;
                workExperience.AnimationUrl = viewmodel.AnimationUrl;

                var TagToAdd = uow.Context.WorkExperienceTags.Where(x => tagsid.Contains(x.Id)).ToList();

                workExperience.WorkExperTags.Clear();

                foreach (var tag in TagToAdd)
                {
                    workExperience.WorkExperTags.Add(tag);
                }

                uow.WorkExperienceRepository.Update(workExperience);
                uow.Commit();
        
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var workExperience = uow.Context.WorkExperiences.Include("WorkExperTags").SingleOrDefault(x => x.Id == id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id = workExperience.Id,
                MainTitle = workExperience.MainTitle,
                Title = workExperience.Title,
                AnimationUrl = workExperience.AnimationUrl,
                Content = workExperience.Content,

            };

            int[] tagsId = workExperience.WorkExperTags.Select(x => x.Id).ToArray();
            viewmodel.TagsId = tagsId;

            TagsData();

            uow.WorkExperienceRepository.Remove(workExperience);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var workExperience = uow.Context.WorkExperiences.Include("WorkExperTags").SingleOrDefault(x => x.Id == id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id = workExperience.Id,
                MainTitle = workExperience.MainTitle,
                Title = workExperience.Title,
                AnimationUrl = workExperience.AnimationUrl,
                Content = workExperience.Content,

            };

            int[] tagsId = workExperience.WorkExperTags.Select(x => x.Id).ToArray();
            viewmodel.TagsId = tagsId;

            TagsData();

            return View(viewmodel);
        }
    }
}