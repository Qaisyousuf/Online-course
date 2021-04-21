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
    public class CourseContnetExplanationController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseContnetExplanationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCourseContentExplanation()
        {
            var courseContentExplanation = uow.CourseContentExplanationRepository.GetAll();

            List<CourseContentExplanationViewModel> viewmodel = new List<CourseContentExplanationViewModel>();

            foreach (var item in courseContentExplanation)
            {
                viewmodel.Add(new CourseContentExplanationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseContentExplanationViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseContentExplanationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseConetentExplnation = new CourseContentExplanation
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.CourseContentExplanationRepository.Add(courseConetentExplnation);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseContentExplnation = uow.CourseContentExplanationRepository.GetById(id);

            CourseContentExplanationViewModel viewmodel = new CourseContentExplanationViewModel
            {
                Id=courseContentExplnation.Id,
                MainTitle=courseContentExplnation.MainTitle,
                Content=courseContentExplnation.Content,
                ImageUrl=courseContentExplnation.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseContentExplanationViewModel viewmodle)
        {
            if(ModelState.IsValid)
            {
                var courseContent = uow.CourseContentExplanationRepository.GetById(viewmodle.Id);

                courseContent.Id = viewmodle.Id;
                courseContent.MainTitle = viewmodle.MainTitle;
                courseContent.Content = viewmodle.Content;
                courseContent.ImageUrl = viewmodle.ImageUrl;

                uow.CourseContentExplanationRepository.Update(courseContent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseContent = uow.CourseContentExplanationRepository.GetById(id);

            CourseContentExplanationViewModel viewmodel = new CourseContentExplanationViewModel
            {
                Id=courseContent.Id,
                MainTitle=courseContent.MainTitle,
                Content=courseContent.Content,
                ImageUrl=courseContent.ImageUrl,
            };

            uow.CourseContentExplanationRepository.Remove(courseContent);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseContentExplnation = uow.CourseContentExplanationRepository.GetById(id);

            CourseContentExplanationViewModel viewmodel = new CourseContentExplanationViewModel
            {
                Id = courseContentExplnation.Id,
                MainTitle = courseContentExplnation.MainTitle,
                Content = courseContentExplnation.Content,
                ImageUrl = courseContentExplnation.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}