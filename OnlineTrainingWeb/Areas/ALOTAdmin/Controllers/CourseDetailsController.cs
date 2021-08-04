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
    public class CourseDetailsController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseDetailsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCourseDatailsData()
        {
            var courseDetails = uow.CourseDetailsRepository.GetAll();
            List<CourseDetailsViewModel> viewmodel = new List<CourseDetailsViewModel>();

            foreach (var item in courseDetails)
            {
                viewmodel.Add(new CourseDetailsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Duration=item.Duration,
                    Language=item.Language,
                    ProgramName=item.ProgramName,
                    VideoLanguage=item.VideoLanguage,
                    Trainer=item.Trainer,
                    ImageUrl=item.ImageUrl,
                    Certification=item.Certification,
                    Level=item.Level,
                    Availability=item.Availability,
                    SutdentFinished=item.SutdentFinished,
                    SubContents=item.SubContents,
                    RegisterButton=item.RegisterButton,
                    RegisterButtonUrl=item.RegisterButtonUrl,
                    CourseType=item.CourseType,
                    LifeTimeAccess=item.LifeTimeAccess,
                    NumArticales=item.NumArticales,
                    
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseDetailsViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseDetails = new CourseDetails
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Title = viewmodel.Title,
                    Duration = viewmodel.Duration,
                    Language = viewmodel.Language,
                    ProgramName = viewmodel.ProgramName,
                    VideoLanguage = viewmodel.VideoLanguage,
                    Trainer = viewmodel.Trainer,
                    ImageUrl = viewmodel.ImageUrl,
                    Certification = viewmodel.Certification,
                    Level = viewmodel.Level,
                    Availability = viewmodel.Availability,
                    SutdentFinished = viewmodel.SutdentFinished,
                    SubContents = viewmodel.SubContents,
                    CourseType = viewmodel.CourseType,
                    RegisterButton = viewmodel.RegisterButton,
                    RegisterButtonUrl = viewmodel.RegisterButtonUrl,
                    LifeTimeAccess=viewmodel.LifeTimeAccess,
                    NumArticales=viewmodel.NumArticales,

                };

                uow.CourseDetailsRepository.Add(courseDetails);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseDetails = uow.CourseDetailsRepository.GetById(id);

            CourseDetailsViewModel viewmodel = new CourseDetailsViewModel
            {
                Id=courseDetails.Id,
                MainTitle=courseDetails.MainTitle,
                Title=courseDetails.Title,
                Duration=courseDetails.Duration,
                Language=courseDetails.Language,
                ProgramName=courseDetails.ProgramName,
                VideoLanguage=courseDetails.VideoLanguage,
                Trainer=courseDetails.Trainer,
                ImageUrl=courseDetails.ImageUrl,
                Certification=courseDetails.Certification,
                Level=courseDetails.Level,
                Availability=courseDetails.Availability,
                SutdentFinished=courseDetails.SutdentFinished,
                SubContents=courseDetails.SubContents,
                RegisterButton=courseDetails.RegisterButton,
                RegisterButtonUrl=courseDetails.RegisterButtonUrl,
                LifeTimeAccess=courseDetails.LifeTimeAccess,
                CourseType=courseDetails.CourseType,
                NumArticales=courseDetails.NumArticales,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseDetails = uow.CourseDetailsRepository.GetById(viewmodel.Id);

                courseDetails.Id = viewmodel.Id;
                courseDetails.MainTitle = viewmodel.MainTitle;
                courseDetails.Title = viewmodel.Title;
                courseDetails.Duration = viewmodel.Duration;
                courseDetails.Language = viewmodel.Language;
                courseDetails.ProgramName = viewmodel.ProgramName;
                courseDetails.VideoLanguage = viewmodel.VideoLanguage;
                courseDetails.Trainer = viewmodel.Trainer;
                courseDetails.ImageUrl = viewmodel.ImageUrl;
                courseDetails.Certification = viewmodel.Certification;
                courseDetails.Level = viewmodel.Level;
                courseDetails.Availability = viewmodel.Availability;
                courseDetails.SutdentFinished = viewmodel.SutdentFinished;
                courseDetails.SubContents = viewmodel.SubContents;
                courseDetails.RegisterButton = viewmodel.RegisterButton;
                courseDetails.RegisterButtonUrl = viewmodel.RegisterButtonUrl;
                courseDetails.LifeTimeAccess = viewmodel.LifeTimeAccess;
                courseDetails.NumArticales = viewmodel.NumArticales;
                courseDetails.CourseType = viewmodel.CourseType;

                uow.CourseDetailsRepository.Update(courseDetails);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseDetails = uow.CourseDetailsRepository.GetById(id);

            CourseDetailsViewModel viewmodel = new CourseDetailsViewModel
            {
                Id=courseDetails.Id,
                MainTitle=courseDetails.MainTitle,
                Title=courseDetails.Title,
                Duration=courseDetails.Duration,
                Language=courseDetails.Language,
                ProgramName=courseDetails.ProgramName,
                VideoLanguage=courseDetails.VideoLanguage,
                Trainer=courseDetails.Trainer,
                ImageUrl=courseDetails.ImageUrl,
                Certification=courseDetails.Certification,
                Level=courseDetails.Level,
                Availability=courseDetails.Availability,
                SutdentFinished=courseDetails.SutdentFinished,
                SubContents=courseDetails.SubContents,
                RegisterButton=courseDetails.RegisterButton,
                RegisterButtonUrl=courseDetails.RegisterButtonUrl,
                LifeTimeAccess=courseDetails.LifeTimeAccess,
                CourseType=courseDetails.CourseType,
                NumArticales=courseDetails.NumArticales,
            };

            uow.CourseDetailsRepository.Remove(courseDetails);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseDetails = uow.CourseDetailsRepository.GetById(id);

            CourseDetailsViewModel viewmodel = new CourseDetailsViewModel
            {
                Id = courseDetails.Id,
                MainTitle = courseDetails.MainTitle,
                Title = courseDetails.Title,
                Duration = courseDetails.Duration,
                Language = courseDetails.Language,
                ProgramName = courseDetails.ProgramName,
                VideoLanguage = courseDetails.VideoLanguage,
                Trainer = courseDetails.Trainer,
                ImageUrl = courseDetails.ImageUrl,
                Certification = courseDetails.Certification,
                Level = courseDetails.Level,
                Availability = courseDetails.Availability,
                SutdentFinished = courseDetails.SutdentFinished,
                SubContents = courseDetails.SubContents,
                RegisterButton = courseDetails.RegisterButton,
                RegisterButtonUrl = courseDetails.RegisterButtonUrl,
                LifeTimeAccess = courseDetails.LifeTimeAccess,
                CourseType = courseDetails.CourseType,
                NumArticales = courseDetails.NumArticales,
            };

            return View(viewmodel);
        }

    }
}