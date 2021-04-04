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
    public class CourseEachSectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseEachSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/CourseEachSection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourseEachSection()
        {
            var courseEachSection = uow.CourseSubSectionRepository.GetAll();

            List<CourseEachSectionViewModel> viewmodel = new List<CourseEachSectionViewModel>();

            foreach (var item in courseEachSection)
            {
                viewmodel.Add(new CourseEachSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    Duration=item.Duration,
                    ReadMoreButton=item.ReadMoreButton,
                    ReadMoreButtonUrl=item.ReadMoreButtonUrl,
                    DownloadCurriculumButton=item.DownloadCurriculumButton,
                    DwonloadCurriculumText=item.DwonloadCurriculumText,
                });

              
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseEachSectionViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseEachSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseEachSection = new CourseEachSection
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    ImageUrl=viewmodel.ImageUrl,
                    Duration=viewmodel.Duration,
                    ReadMoreButton=viewmodel.ReadMoreButton,
                    ReadMoreButtonUrl=viewmodel.ReadMoreButtonUrl,
                    DownloadCurriculumButton=viewmodel.DownloadCurriculumButton,
                    DwonloadCurriculumText=viewmodel.DwonloadCurriculumText,
                    Content=viewmodel.Content,
                };

                uow.CourseSubSectionRepository.Add(courseEachSection);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseEachSection = uow.CourseSubSectionRepository.GetById(id);

            CourseEachSectionViewModel viewmodel = new CourseEachSectionViewModel
            {
                Id=courseEachSection.Id,
                MainTitle=courseEachSection.MainTitle,
                Title=courseEachSection.Title,
                Content=courseEachSection.Content,
                ImageUrl=courseEachSection.ImageUrl,
                Duration=courseEachSection.Duration,
                ReadMoreButton=courseEachSection.ReadMoreButton,
                ReadMoreButtonUrl=courseEachSection.ReadMoreButtonUrl,
                DownloadCurriculumButton=courseEachSection.DownloadCurriculumButton,
                DwonloadCurriculumText=courseEachSection.DwonloadCurriculumText,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseEachSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseEachSection = uow.CourseSubSectionRepository.GetById(viewmodel.Id);

                courseEachSection.Id = viewmodel.Id;
                courseEachSection.MainTitle = viewmodel.MainTitle;
                courseEachSection.Title = viewmodel.Title;
                courseEachSection.Content = viewmodel.Content;
                courseEachSection.ImageUrl = viewmodel.ImageUrl;
                courseEachSection.Duration = viewmodel.Duration;
                courseEachSection.ReadMoreButton = viewmodel.ReadMoreButton;
                courseEachSection.ReadMoreButtonUrl = viewmodel.ReadMoreButtonUrl;
                courseEachSection.DownloadCurriculumButton = viewmodel.DownloadCurriculumButton;
                courseEachSection.DwonloadCurriculumText = viewmodel.DwonloadCurriculumText;

                uow.CourseSubSectionRepository.Update(courseEachSection);
                uow.Commit();
                return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseEachSection = uow.CourseSubSectionRepository.GetById(id);

            CourseEachSectionViewModel viewmodel = new CourseEachSectionViewModel
            {
                Id = courseEachSection.Id,
                MainTitle = courseEachSection.MainTitle,
                Title = courseEachSection.Title,
                Content = courseEachSection.Content,
                ImageUrl = courseEachSection.ImageUrl,
                Duration = courseEachSection.Duration,
                ReadMoreButton = courseEachSection.ReadMoreButton,
                ReadMoreButtonUrl = courseEachSection.ReadMoreButtonUrl,
                DownloadCurriculumButton = courseEachSection.DownloadCurriculumButton,
                DwonloadCurriculumText = courseEachSection.DwonloadCurriculumText,
            };

            uow.CourseSubSectionRepository.Remove(courseEachSection);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseEachSection = uow.CourseSubSectionRepository.GetById(id);

            CourseEachSectionViewModel viewmodel = new CourseEachSectionViewModel
            {
                Id = courseEachSection.Id,
                MainTitle = courseEachSection.MainTitle,
                Title = courseEachSection.Title,
                Content = courseEachSection.Content,
                ImageUrl = courseEachSection.ImageUrl,
                Duration = courseEachSection.Duration,
                ReadMoreButton = courseEachSection.ReadMoreButton,
                ReadMoreButtonUrl = courseEachSection.ReadMoreButtonUrl,
                DownloadCurriculumButton = courseEachSection.DownloadCurriculumButton,
                DwonloadCurriculumText = courseEachSection.DwonloadCurriculumText,
            };
            return View(viewmodel);
        }
    }
}