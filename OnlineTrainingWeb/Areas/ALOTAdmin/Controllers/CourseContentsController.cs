using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Model;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class CourseContentsController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseContentsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourseContentsData()
        {
            var courseContent = uow.CourseContenntRepository.GetAll();

            List<CourseContentsViewModel> viewmodel = new List<CourseContentsViewModel>();

            foreach (var item in courseContent)
            {
                viewmodel.Add(new CourseContentsViewModel
                {
                    Id = item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    AnimationUrl=item.AnimationUrl,

                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseContentsViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseContentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseContent = new CourseContents
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    AnimationUrl=viewmodel.AnimationUrl,
                };

                uow.CourseContenntRepository.Add(courseContent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseContent = uow.CourseContenntRepository.GetById(id);

            CourseContentsViewModel viewmodel = new CourseContentsViewModel
            {
                Id=courseContent.Id,
                MainTitle=courseContent.MainTitle,
                Title=courseContent.Title,
                Content=courseContent.Content,
                AnimationUrl=courseContent.AnimationUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseContentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseContents = uow.CourseContenntRepository.GetById(viewmodel.Id);

                courseContents.Id = viewmodel.Id;
                courseContents.MainTitle = viewmodel.MainTitle;
                courseContents.Title = viewmodel.Title;
                courseContents.Content = viewmodel.Content;
                courseContents.AnimationUrl = viewmodel.AnimationUrl;

                uow.CourseContenntRepository.Update(courseContents);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseContent = uow.CourseContenntRepository.GetById(id);

            CourseContentsViewModel viewmodel = new CourseContentsViewModel
            {
                Id = courseContent.Id,
                MainTitle = courseContent.MainTitle,
                Title = courseContent.Title,
                Content = courseContent.Content,
                AnimationUrl = courseContent.AnimationUrl,
            };

            uow.CourseContenntRepository.Remove(courseContent);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseContent = uow.CourseContenntRepository.GetById(id);

            CourseContentsViewModel viewmodel = new CourseContentsViewModel
            {
                Id = courseContent.Id,
                MainTitle = courseContent.MainTitle,
                Title = courseContent.Title,
                Content = courseContent.Content,
                AnimationUrl = courseContent.AnimationUrl,
            };

            return View(viewmodel);
        }
    }
}