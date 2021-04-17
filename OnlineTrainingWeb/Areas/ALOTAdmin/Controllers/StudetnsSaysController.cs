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
    public class StudetnsSaysController : Controller
    {
        private readonly IUnitOfWork uow;

        public StudetnsSaysController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStudentSaysData()
        {
            var studentSays = uow.StudentsSaysRepository.GetAll();

            List<StudentsSayViewModel> viewmodel = new List<StudentsSayViewModel>();

            foreach (var item in studentSays)
            {
                viewmodel.Add(new StudentsSayViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ProgramName=item.ProgramName,
                    StudentName=item.StudentName,
                    PicUrl=item.PicUrl,
                    CountryName=item.CountryName,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentsSayViewModel());
        }

        [HttpPost]
        public ActionResult Create(StudentsSayViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var studentSays = new StudentsSay
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ProgramName=viewmodel.ProgramName,
                    StudentName=viewmodel.StudentName,
                    PicUrl=viewmodel.PicUrl,
                    CountryName=viewmodel.CountryName,
                };

                uow.StudentsSaysRepository.Add(studentSays);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var studentSays = uow.StudentsSaysRepository.GetById(id);

            StudentsSayViewModel viewmodel = new StudentsSayViewModel
            {
                Id=studentSays.Id,
                MainTitle=studentSays.MainTitle,
                Content=studentSays.Content,
                ProgramName=studentSays.ProgramName,
                StudentName=studentSays.StudentName,
                PicUrl=studentSays.PicUrl,
                CountryName=studentSays.CountryName,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(StudentsSayViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var studentSays = uow.StudentsSaysRepository.GetById(viewmodel.Id);

                studentSays.Id = viewmodel.Id;
                studentSays.MainTitle = viewmodel.MainTitle;
                studentSays.ProgramName = viewmodel.ProgramName;
                studentSays.StudentName = viewmodel.StudentName;
                studentSays.PicUrl = viewmodel.PicUrl;
                studentSays.Content = viewmodel.Content;
                studentSays.CountryName = viewmodel.CountryName;

                uow.StudentsSaysRepository.Update(studentSays);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var studentSays = uow.StudentsSaysRepository.GetById(id);

            StudentsSayViewModel viewmodel = new StudentsSayViewModel
            {
                Id=studentSays.Id,
                MainTitle=studentSays.MainTitle,
                Content=studentSays.Content,
                ProgramName=studentSays.ProgramName,
                StudentName=studentSays.StudentName,
                CountryName=studentSays.CountryName,
                PicUrl=studentSays.PicUrl,
            };

            uow.StudentsSaysRepository.Remove(studentSays);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var studentSays = uow.StudentsSaysRepository.GetById(id);

            StudentsSayViewModel viewmodel = new StudentsSayViewModel
            {
                Id = studentSays.Id,
                MainTitle = studentSays.MainTitle,
                Content = studentSays.Content,
                ProgramName = studentSays.ProgramName,
                StudentName = studentSays.StudentName,
                PicUrl = studentSays.PicUrl,
                CountryName = studentSays.CountryName,
            };

            return View(viewmodel);
        }
    }
}