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
    public class CourseDescriptionController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseDescriptionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCourseDescriptionData()
        {
            var courseDescription = uow.CourseDescriptionRepository.GetAll();

            List<CourseDescriptionViewModel> viewmodel = new List<CourseDescriptionViewModel>();

            foreach (var item in courseDescription)
            {
                viewmodel.Add(new CourseDescriptionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    TakeCourseButton=item.TakeCourseButton,
                    TakeCourseButtonUrl=item.TakeCourseButtonUrl,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseDescriptionViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseDescriptionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseDescription = new CourseDescription
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    TakeCourseButton=viewmodel.TakeCourseButton,
                    TakeCourseButtonUrl=viewmodel.TakeCourseButtonUrl,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.CourseDescriptionRepository.Add(courseDescription);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseDescription = uow.CourseDescriptionRepository.GetById(id);

            CourseDescriptionViewModel viewmodel = new CourseDescriptionViewModel
            {
                Id=courseDescription.Id,
                MainTitle=courseDescription.MainTitle,
                Title=courseDescription.Title,
                Content=courseDescription.Content,
                TakeCourseButton=courseDescription.TakeCourseButton,
                TakeCourseButtonUrl=courseDescription.TakeCourseButtonUrl,
                ImageUrl=courseDescription.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseDescriptionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseDescription = uow.CourseDescriptionRepository.GetById(viewmodel.Id);

                courseDescription.Id = viewmodel.Id;
                courseDescription.MainTitle = viewmodel.MainTitle;
                courseDescription.Title = viewmodel.Title;
                courseDescription.Content = viewmodel.Content;
                courseDescription.TakeCourseButton = viewmodel.TakeCourseButton;
                courseDescription.TakeCourseButtonUrl = viewmodel.TakeCourseButtonUrl;
                courseDescription.ImageUrl = viewmodel.ImageUrl;

                uow.CourseDescriptionRepository.Update(courseDescription);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseDescription = uow.CourseDescriptionRepository.GetById(id);

            CourseDescriptionViewModel viewmodel = new CourseDescriptionViewModel
            {
                Id = courseDescription.Id,
                MainTitle = courseDescription.MainTitle,
                Title = courseDescription.Title,
                Content = courseDescription.Content,
                TakeCourseButton = courseDescription.TakeCourseButton,
                TakeCourseButtonUrl = courseDescription.TakeCourseButtonUrl,
                ImageUrl = courseDescription.ImageUrl,
            };

            uow.CourseDescriptionRepository.Remove(courseDescription);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseDescription = uow.CourseDescriptionRepository.GetById(id);

            CourseDescriptionViewModel viewmodel = new CourseDescriptionViewModel
            {
                Id = courseDescription.Id,
                MainTitle = courseDescription.MainTitle,
                Title = courseDescription.Title,
                Content = courseDescription.Content,
                TakeCourseButton = courseDescription.TakeCourseButton,
                TakeCourseButtonUrl = courseDescription.TakeCourseButtonUrl,
                ImageUrl = courseDescription.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}