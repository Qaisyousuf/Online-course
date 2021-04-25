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
    public class LaunchYourCodingCareerController : Controller
    {
        private readonly IUnitOfWork uow;

        public LaunchYourCodingCareerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetLaunchYourCodingCareerData()
        {
            var laungYoucode = uow.launchYourCoding.GetAll();

            List<LaunchYourCodingCareerViewModel> viewmodel = new List<LaunchYourCodingCareerViewModel>();

            foreach (var item in laungYoucode)
            {
                viewmodel.Add(new LaunchYourCodingCareerViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    Content = item.Content,
                    VideoUrl = item.VideoUrl,
                    AnimationUrl = item.AnimationUrl,
                    RegisterButton = item.RegisterButton,
                    RegisterButtonUrl = item.RegisterButtonUrl,
                    TakeCourseButton = item.TakeCourseButton,
                    TakeCourseButtonUrl = item.TakeCourseButtonUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new LaunchYourCodingCareerViewModel());
        }

        [HttpPost]
        public ActionResult Create(LaunchYourCodingCareerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var launchYourCodeing = new LaunchYourCodingCareer
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Content = viewmodel.Content,
                    VideoUrl = viewmodel.VideoUrl,
                    AnimationUrl = viewmodel.AnimationUrl,
                    RegisterButton = viewmodel.RegisterButton,
                    RegisterButtonUrl = viewmodel.RegisterButtonUrl,
                    TakeCourseButton = viewmodel.TakeCourseButton,
                    TakeCourseButtonUrl = viewmodel.TakeCourseButtonUrl,
                };

                uow.launchYourCoding.Add(launchYourCodeing);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var launchYourCode = uow.launchYourCoding.GetById(id);

            LaunchYourCodingCareerViewModel viewmodel = new LaunchYourCodingCareerViewModel
            {
                Id=launchYourCode.Id,
                MainTitle=launchYourCode.MainTitle,
                Content=launchYourCode.Content,
                VideoUrl=launchYourCode.VideoUrl,
                AnimationUrl=launchYourCode.AnimationUrl,
                RegisterButton=launchYourCode.RegisterButton,
                RegisterButtonUrl=launchYourCode.RegisterButtonUrl,
                TakeCourseButton=launchYourCode.TakeCourseButton,
                TakeCourseButtonUrl=launchYourCode.TakeCourseButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(LaunchYourCodingCareerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var lauchYouCode = uow.launchYourCoding.GetById(viewmodel.Id);

                lauchYouCode.Id = viewmodel.Id;
                lauchYouCode.MainTitle = viewmodel.MainTitle;
                lauchYouCode.Content = viewmodel.Content;
                lauchYouCode.VideoUrl = viewmodel.VideoUrl;
                lauchYouCode.AnimationUrl = viewmodel.AnimationUrl;
                lauchYouCode.TakeCourseButton = viewmodel.TakeCourseButton;
                lauchYouCode.TakeCourseButtonUrl = viewmodel.TakeCourseButtonUrl;
                lauchYouCode.RegisterButton = viewmodel.RegisterButton;
                lauchYouCode.RegisterButtonUrl = viewmodel.RegisterButtonUrl;

                uow.launchYourCoding.Update(lauchYouCode);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var launchYourCode = uow.launchYourCoding.GetById(id);

            LaunchYourCodingCareerViewModel viewmodel = new LaunchYourCodingCareerViewModel
            {
                Id = launchYourCode.Id,
                MainTitle = launchYourCode.MainTitle,
                Content = launchYourCode.Content,
                VideoUrl = launchYourCode.VideoUrl,
                AnimationUrl = launchYourCode.AnimationUrl,
                RegisterButton = launchYourCode.RegisterButton,
                RegisterButtonUrl = launchYourCode.RegisterButtonUrl,
                TakeCourseButton = launchYourCode.TakeCourseButton,
                TakeCourseButtonUrl = launchYourCode.TakeCourseButtonUrl,
            };

            uow.launchYourCoding.Remove(launchYourCode);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var launchYourCode = uow.launchYourCoding.GetById(id);

            LaunchYourCodingCareerViewModel viewmodel = new LaunchYourCodingCareerViewModel
            {
                Id = launchYourCode.Id,
                MainTitle = launchYourCode.MainTitle,
                Content = launchYourCode.Content,
                VideoUrl = launchYourCode.VideoUrl,
                AnimationUrl = launchYourCode.AnimationUrl,
                RegisterButton = launchYourCode.RegisterButton,
                RegisterButtonUrl = launchYourCode.RegisterButtonUrl,
                TakeCourseButton = launchYourCode.TakeCourseButton,
                TakeCourseButtonUrl = launchYourCode.TakeCourseButtonUrl,
            };

            return View(viewmodel);
        }
    }
}