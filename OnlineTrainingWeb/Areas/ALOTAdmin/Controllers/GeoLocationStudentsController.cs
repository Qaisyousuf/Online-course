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
    public class GeoLocationStudentsController : Controller
    {
        private readonly IUnitOfWork uow;

        public GeoLocationStudentsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            GeoLocationRelatedData();
            return View();
        }

        private void GeoLocationRelatedData()
        {
            ViewBag.Country = uow.CountryNamesRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetGeoLocationData()
        {
            var geoLocationStudent = uow.GeolocationStudentsRepository.GetAll("CountryName");

            List<GeolocationStudentsViewModel> viewmodel = new List<GeolocationStudentsViewModel>();

            foreach (var item in geoLocationStudent)
            {
                viewmodel.Add(new GeolocationStudentsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Name=item.Name,
                    ProgramName=item.ProgramName,
                    CountryFlag=item.CountryFlag,
                    CountryId=item.CountryId,
                    CountryName=item.CountryName,
                });
            }

            
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Create()
        {
            GeoLocationRelatedData();
            return View(new GeolocationStudentsViewModel());
        }

        [HttpPost]
        public ActionResult Create(GeolocationStudentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var geoLocationStudent = new GeolocationStudents
                {

                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Name=viewmodel.Name,
                    ProgramName=viewmodel.ProgramName,
                    CountryFlag=viewmodel.CountryFlag,
                    CountryId=viewmodel.CountryId,
                    CountryName=viewmodel.CountryName,
                };

                uow.GeolocationStudentsRepository.Add(geoLocationStudent);
                uow.Commit();
            }
            
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var geoLocationStudent = uow.GeolocationStudentsRepository.GetById(id);

            GeolocationStudentsViewModel viewmodel = new GeolocationStudentsViewModel
            {
                Id=geoLocationStudent.Id,
                MainTitle=geoLocationStudent.MainTitle,
                Title=geoLocationStudent.Title,
                Name=geoLocationStudent.Name,
                ProgramName=geoLocationStudent.ProgramName,
                CountryFlag=geoLocationStudent.CountryFlag,
                CountryId=geoLocationStudent.CountryId,
                CountryName=geoLocationStudent.CountryName,
            };
            GeoLocationRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(GeolocationStudentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var geoLocation = uow.GeolocationStudentsRepository.GetById(viewmodel.Id);

                geoLocation.Id = viewmodel.Id;
                geoLocation.MainTitle = viewmodel.MainTitle;
                geoLocation.Title = viewmodel.Title;
                geoLocation.Name = viewmodel.Name;
                geoLocation.ProgramName = viewmodel.ProgramName;
                geoLocation.CountryFlag = viewmodel.CountryFlag;
                geoLocation.CountryId = viewmodel.CountryId;
                geoLocation.CountryName = viewmodel.CountryName;

                uow.GeolocationStudentsRepository.Update(geoLocation);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var geoLocationStudent = uow.GeolocationStudentsRepository.GetById(id);

            GeolocationStudentsViewModel viewmodel = new GeolocationStudentsViewModel
            {
                Id = geoLocationStudent.Id,
                MainTitle = geoLocationStudent.MainTitle,
                Title = geoLocationStudent.Title,
                Name = geoLocationStudent.Name,
                ProgramName = geoLocationStudent.ProgramName,
                CountryFlag = geoLocationStudent.CountryFlag,
                CountryId = geoLocationStudent.CountryId,
                CountryName = geoLocationStudent.CountryName,
            };

            uow.GeolocationStudentsRepository.Remove(geoLocationStudent);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var geoLocationStudent = uow.GeolocationStudentsRepository.GetById(id);

            GeolocationStudentsViewModel viewmodel = new GeolocationStudentsViewModel
            {
                Id = geoLocationStudent.Id,
                MainTitle = geoLocationStudent.MainTitle,
                Title = geoLocationStudent.Title,
                Name = geoLocationStudent.Name,
                ProgramName = geoLocationStudent.ProgramName,
                CountryFlag = geoLocationStudent.CountryFlag,
                CountryId = geoLocationStudent.CountryId,
                CountryName = geoLocationStudent.CountryName,
            };
            GeoLocationRelatedData();
            return View(viewmodel);
        }
    }
}