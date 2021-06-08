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
    public class HowOnlineTrainingWorksController : Controller
    {
        private readonly IUnitOfWork uow;

        public HowOnlineTrainingWorksController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetHowOnlineTrainingWorksData()
        {
            var howOnlineTrainingWroks = uow.HowOnlineTrainingWorksRepository.GetAll();

            List<HowOnlineTrainingWorksViewModel> viewmodel = new List<HowOnlineTrainingWorksViewModel>();

            foreach (var item in howOnlineTrainingWroks)
            {
                viewmodel.Add(new HowOnlineTrainingWorksViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    VideoUrl=item.VideoUrl,
                    AnimationUrl=item.AnimationUrl,
                    LogoUrlandroid=item.LogoUrlandroid,
                    LogoUrlIOS=item.LogoUrlIOS,
                    ApplicationDownloadButton=item.ApplicationDownloadButton,
                    ApplicationDownloadUrl=item.ApplicationDownloadUrl,
                });

               
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new HowOnlineTrainingWorksViewModel());
        }

        [HttpPost]
        public ActionResult Create(HowOnlineTrainingWorksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var howOnlineTrainingWorks = new HowOnlineTrainingWorks
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    VideoUrl=viewmodel.VideoUrl,
                    AnimationUrl=viewmodel.AnimationUrl,
                    LogoUrlIOS=viewmodel.LogoUrlIOS,
                    LogoUrlandroid=viewmodel.LogoUrlandroid,
                    ApplicationDownloadButton=viewmodel.ApplicationDownloadButton,
                    ApplicationDownloadUrl=viewmodel.ApplicationDownloadUrl,
                };

                uow.HowOnlineTrainingWorksRepository.Add(howOnlineTrainingWorks);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var howOnlineTrainingWorks = uow.HowOnlineTrainingWorksRepository.GetById(id);

            HowOnlineTrainingWorksViewModel viewmodel = new HowOnlineTrainingWorksViewModel
            {
                Id=howOnlineTrainingWorks.Id,
                MainTitle=howOnlineTrainingWorks.MainTitle,
                Title=howOnlineTrainingWorks.Title,
                Content=howOnlineTrainingWorks.Content,
                VideoUrl=howOnlineTrainingWorks.VideoUrl,
                AnimationUrl=howOnlineTrainingWorks.AnimationUrl,
                LogoUrlandroid=howOnlineTrainingWorks.LogoUrlandroid,
                LogoUrlIOS=howOnlineTrainingWorks.LogoUrlIOS,
                ApplicationDownloadButton=howOnlineTrainingWorks.ApplicationDownloadButton,
                ApplicationDownloadUrl=howOnlineTrainingWorks.ApplicationDownloadUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HowOnlineTrainingWorksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var howOnlineTrainingWorks = uow.HowOnlineTrainingWorksRepository.GetById(viewmodel.Id);

                howOnlineTrainingWorks.Id = viewmodel.Id;
                howOnlineTrainingWorks.MainTitle = viewmodel.MainTitle;
                howOnlineTrainingWorks.Title = viewmodel.Title;
                howOnlineTrainingWorks.Content = viewmodel.Content;
                howOnlineTrainingWorks.VideoUrl = viewmodel.VideoUrl;
                howOnlineTrainingWorks.AnimationUrl = viewmodel.AnimationUrl;
                howOnlineTrainingWorks.LogoUrlandroid = viewmodel.LogoUrlandroid;
                howOnlineTrainingWorks.LogoUrlIOS = viewmodel.LogoUrlIOS;
                howOnlineTrainingWorks.ApplicationDownloadButton = viewmodel.ApplicationDownloadButton;
                howOnlineTrainingWorks.ApplicationDownloadUrl = viewmodel.ApplicationDownloadUrl;

                uow.HowOnlineTrainingWorksRepository.Update(howOnlineTrainingWorks);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var howOnlineTrainingWorks = uow.HowOnlineTrainingWorksRepository.GetById(id);

            HowOnlineTrainingWorksViewModel viewmodel = new HowOnlineTrainingWorksViewModel
            {
                Id = howOnlineTrainingWorks.Id,
                MainTitle = howOnlineTrainingWorks.MainTitle,
                Title = howOnlineTrainingWorks.Title,
                Content = howOnlineTrainingWorks.Content,
                VideoUrl = howOnlineTrainingWorks.VideoUrl,
                AnimationUrl = howOnlineTrainingWorks.AnimationUrl,
                LogoUrlandroid = howOnlineTrainingWorks.LogoUrlandroid,
                LogoUrlIOS = howOnlineTrainingWorks.LogoUrlIOS,
                ApplicationDownloadButton = howOnlineTrainingWorks.ApplicationDownloadButton,
                ApplicationDownloadUrl = howOnlineTrainingWorks.ApplicationDownloadUrl,
            };

            uow.HowOnlineTrainingWorksRepository.Remove(howOnlineTrainingWorks);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var howOnlineTrainingWorks = uow.HowOnlineTrainingWorksRepository.GetById(id);

            HowOnlineTrainingWorksViewModel viewmodel = new HowOnlineTrainingWorksViewModel
            {
                Id = howOnlineTrainingWorks.Id,
                MainTitle = howOnlineTrainingWorks.MainTitle,
                Title = howOnlineTrainingWorks.Title,
                Content = howOnlineTrainingWorks.Content,
                VideoUrl = howOnlineTrainingWorks.VideoUrl,
                AnimationUrl = howOnlineTrainingWorks.AnimationUrl,
                LogoUrlandroid = howOnlineTrainingWorks.LogoUrlandroid,
                LogoUrlIOS = howOnlineTrainingWorks.LogoUrlIOS,
                ApplicationDownloadButton = howOnlineTrainingWorks.ApplicationDownloadButton,
                ApplicationDownloadUrl = howOnlineTrainingWorks.ApplicationDownloadUrl,
            };

            return View(viewmodel);
        }
    }
}