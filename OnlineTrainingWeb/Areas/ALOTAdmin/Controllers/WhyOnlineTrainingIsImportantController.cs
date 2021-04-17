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
    public class WhyOnlineTrainingIsImportantController : Controller
    {
        private readonly IUnitOfWork uow;

        public WhyOnlineTrainingIsImportantController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWhyOnlineTrainingIsImportatnetData()
        {
            var whyOnlineTrainingIsImprotatnet = uow.WhyOnlineTrainingIsImportantRepository.GetAll();

            List<WhyOnlineTrainingIsImportantViewModel> viewmodel = new List<WhyOnlineTrainingIsImportantViewModel>();

            foreach (var item in whyOnlineTrainingIsImprotatnet)
            {
                viewmodel.Add(new WhyOnlineTrainingIsImportantViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainTitle=item.MainTitle,
                    SubContent=item.SubContent,
                    MainContent=item.MainContent,
                    AnimationUrl=item.AnimationUrl,
                    IconUrl=item.IconUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhyOnlineTrainingIsImportantViewModel());
        }

        [HttpPost]
        public ActionResult Create(WhyOnlineTrainingIsImportantViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyOnlineTrainingIsImportent = new WhyOnlineTrainingIsImportant
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    SubContent=viewmodel.SubContent,
                    IconUrl=viewmodel.IconUrl,
                    AnimationUrl=viewmodel.AnimationUrl,
                    MainContent=viewmodel.MainContent,
                };

                uow.WhyOnlineTrainingIsImportantRepository.Add(whyOnlineTrainingIsImportent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whyOnlineTrainingIsImportent = uow.WhyOnlineTrainingIsImportantRepository.GetById(id);

            WhyOnlineTrainingIsImportantViewModel viewmodel = new WhyOnlineTrainingIsImportantViewModel
            {
                Id=whyOnlineTrainingIsImportent.Id,
                MainTitle=whyOnlineTrainingIsImportent.MainTitle,
                Title=whyOnlineTrainingIsImportent.Title,
                MainContent=whyOnlineTrainingIsImportent.MainContent,
                SubContent=whyOnlineTrainingIsImportent.SubContent,
                IconUrl=whyOnlineTrainingIsImportent.IconUrl,
                AnimationUrl=whyOnlineTrainingIsImportent.AnimationUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhyOnlineTrainingIsImportantViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyOnlineTariningIsImportent = uow.WhyOnlineTrainingIsImportantRepository.GetById(viewmodel.Id);

                whyOnlineTariningIsImportent.Id = viewmodel.Id;
                whyOnlineTariningIsImportent.MainTitle = viewmodel.MainTitle;
                whyOnlineTariningIsImportent.Title = viewmodel.Title;
                whyOnlineTariningIsImportent.MainContent = viewmodel.MainContent;
                whyOnlineTariningIsImportent.SubContent = viewmodel.SubContent;
                whyOnlineTariningIsImportent.IconUrl = viewmodel.IconUrl;
                whyOnlineTariningIsImportent.AnimationUrl = viewmodel.AnimationUrl;

                uow.WhyOnlineTrainingIsImportantRepository.Update(whyOnlineTariningIsImportent);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            var whyOnlineTrainingIsImportent = uow.WhyOnlineTrainingIsImportantRepository.GetById(id);

            WhyOnlineTrainingIsImportantViewModel viewmodel = new WhyOnlineTrainingIsImportantViewModel
            {

                Id = whyOnlineTrainingIsImportent.Id,
                MainTitle=whyOnlineTrainingIsImportent.MainTitle,
                Title=whyOnlineTrainingIsImportent.Title,
                MainContent=whyOnlineTrainingIsImportent.MainContent,
                SubContent=whyOnlineTrainingIsImportent.SubContent,
                AnimationUrl=whyOnlineTrainingIsImportent.AnimationUrl,
                IconUrl=whyOnlineTrainingIsImportent.IconUrl,
            };

            uow.WhyOnlineTrainingIsImportantRepository.Remove(whyOnlineTrainingIsImportent);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var whyOnlineTrainingIsImportent = uow.WhyOnlineTrainingIsImportantRepository.GetById(id);

            WhyOnlineTrainingIsImportantViewModel viewmodel = new WhyOnlineTrainingIsImportantViewModel
            {
                Id = whyOnlineTrainingIsImportent.Id,
                MainTitle = whyOnlineTrainingIsImportent.MainTitle,
                Title = whyOnlineTrainingIsImportent.Title,
                MainContent = whyOnlineTrainingIsImportent.MainContent,
                SubContent = whyOnlineTrainingIsImportent.SubContent,
                IconUrl = whyOnlineTrainingIsImportent.IconUrl,
                AnimationUrl = whyOnlineTrainingIsImportent.AnimationUrl,
            };

            return View(viewmodel);
        }
    }
}