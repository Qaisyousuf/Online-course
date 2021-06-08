using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;
using Services;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class CoursePageController : Controller
    {
        private readonly IUnitOfWork uow;

        public CoursePageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void CourseData()
        {
            ViewBag.CourseBanner = uow.CourseBannerRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetCoursePageData()
        {
            var coursePage = uow.CoursePageRepository.GetAll("CourseBanner");

            List<CoursePageViewModel> viewmodel = new List<CoursePageViewModel>();

            foreach (var item in coursePage)
            {
                viewmodel.Add(new CoursePageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    CourseBanner=item.CourseBanner,
                    CourseBannerId=item.CourseBannerId,
                    
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CourseData();
            return View(new CoursePageViewModel());
        }

        [HttpPost]
        public ActionResult Create(CoursePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetCoursePageData();
                return View(viewmodel);
            }

            string slug;

            CoursePage coursePage = new CoursePage();

            coursePage.Id = viewmodel.Id;
            coursePage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);
               
            if(uow.CoursePageRepository.SlugExists(viewmodel.Id,slug))
            {
                GetCoursePageData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            coursePage.Slug = slug;
            coursePage.Content = viewmodel.Content;
            coursePage.CourseBanner = viewmodel.CourseBanner;
            coursePage.CourseBannerId = viewmodel.CourseBannerId;

            uow.CoursePageRepository.Add(coursePage);
            uow.Commit();
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var coursePage = uow.CoursePageRepository.GetById(id);

            CoursePageViewModel viewmodel = new CoursePageViewModel
            {
                Id=coursePage.Id,
                Title=coursePage.Title,
                Slug=coursePage.Slug,
                Content=coursePage.Content,
                CourseBanner=coursePage.CourseBanner,
                CourseBannerId=coursePage.CourseBannerId,
            };

            CourseData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CoursePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                CourseData();
                return View(viewmodel);
            }

            string slug;

            var coursePage = uow.CoursePageRepository.GetById(viewmodel.Id);

            coursePage.Id = viewmodel.Id;
            coursePage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.CoursePageRepository.SlugExists(slug))
            {
                CourseData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            coursePage.Slug = slug;
            coursePage.Content = viewmodel.Content;
            coursePage.CourseBanner = viewmodel.CourseBanner;
            coursePage.CourseBannerId = viewmodel.CourseBannerId;

            uow.CoursePageRepository.Update(coursePage);
            uow.Commit();
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var coursePage = uow.CoursePageRepository.GetById(id);

            CoursePageViewModel viewmodel = new CoursePageViewModel
            {
                Id = coursePage.Id,
                Title = coursePage.Title,
                Slug = coursePage.Slug,
                Content = coursePage.Content,
                CourseBanner = coursePage.CourseBanner,
                CourseBannerId = coursePage.CourseBannerId,
            };

            uow.CoursePageRepository.Remove(coursePage);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var coursePage = uow.CoursePageRepository.GetById(id);

            CoursePageViewModel viewmodel = new CoursePageViewModel
            {
                Id = coursePage.Id,
                Title = coursePage.Title,
                Slug = coursePage.Slug,
                Content = coursePage.Content,
                CourseBanner = coursePage.CourseBanner,
                CourseBannerId = coursePage.CourseBannerId,
            };

            CourseData();
            return View(viewmodel);
        }
    }
}