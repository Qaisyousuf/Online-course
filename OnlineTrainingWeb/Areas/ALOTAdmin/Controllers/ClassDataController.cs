using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Data;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class ClassDataController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleMange = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        private readonly IUnitOfWork uow;

        public ClassDataController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetClassData()
        {
            var classData = uow.ClassDataRepository.GetAll("ApplicationUsers");

            List<ClassDataViewModel> viewmodel = new List<ClassDataViewModel>();
            ViewBag.Users = uow.Context.Users.ToList();
            var UserName = classData.Select(x => x.UserName);
            foreach (var item in classData)
            {
                var datatime = item.ClassStartData;
                var ClassStartTime = Convert.ToDateTime(datatime.ToShortTimeString());
                var ClassStartDate = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new ClassDataViewModel
                {
                    Id=item.Id,
                    Content=item.Content,
                    Title=item.Title,
                    ContactedBy=item.contactedBy,
                    ClassName=item.ClassName,
                    ClassStartData=ClassStartDate,
                    ClassStartTime=ClassStartTime,
                    TotalCourseDays=item.TotalCourseDays,
                    UserName=UserName.ToString(),
                    UserId=item.UserId,
                    ApplicationUsers=item.ApplicationUsers,

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserName = uow.Context.Users.ToList();
            return View(new ClassDataViewModel());

        }
        [HttpPost]
        public ActionResult Create(ClassDataViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {

                var userName = uow.Context.Users.Where(x => x.Id == viewmodel.UserId).Select(x=>x.FullName).FirstOrDefault();

                ViewBag.UserName = uow.Context.Users.Select(x => x.UserName).ToList();
                var time = Convert.ToDateTime(viewmodel.ClassStartTime.ToShortTimeString());
                var date = Convert.ToDateTime(viewmodel.ClassStartData.ToLongDateString());
                var CombinedDataTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                var classData = new ClassData
                {

                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    contactedBy = viewmodel.ContactedBy,
                    ClassName = viewmodel.ClassName,
                    ClassDescription = viewmodel.ClassDescription,
                    TotalCourseDays = viewmodel.TotalCourseDays,
                    Content = viewmodel.Content,
                    UserName=userName,
                    UserId = viewmodel.UserId,
                    ClassStartData=CombinedDataTime,
                    ApplicationUsers = viewmodel.ApplicationUsers,
                };
                uow.ClassDataRepository.Add(classData);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var classData = uow.ClassDataRepository.GetById(id);
            ViewBag.UserName = uow.Context.Users.ToList();
            //ViewBag.UserName = uow.Context.Users.Select(x => x.UserName).ToList();
            var datatime = classData.ClassStartData;
            var ClassStartTime = Convert.ToDateTime(datatime.ToShortTimeString());
            var ClassStartDate = Convert.ToDateTime(datatime.ToShortDateString());
            ClassDataViewModel viewmodel = new ClassDataViewModel
            {
                Id=classData.Id,
                Title=classData.Title,
                ContactedBy=classData.contactedBy,
                Content=classData.Content,
                ClassName=classData.ClassName,
                TotalCourseDays=classData.TotalCourseDays,
                ClassDescription=classData.ClassDescription,
                UserName=classData.UserName,
                UserId=classData.UserId,
                ApplicationUsers=classData.ApplicationUsers,
                ClassStartData=ClassStartDate,
                ClassStartTime=ClassStartTime,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ClassDataViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userName = uow.Context.Users.Where(x => x.Id == viewmodel.UserId).Select(x => x.FullName).FirstOrDefault();

                var time = Convert.ToDateTime(viewmodel.ClassStartTime.ToShortTimeString());
                var date = Convert.ToDateTime(viewmodel.ClassStartData.ToLongDateString());
                var CombinedDataTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                var classData = uow.ClassDataRepository.GetById(viewmodel.Id);

                classData.Id = viewmodel.Id;
                classData.Title = viewmodel.Title;
                classData.Content = viewmodel.Content;
                classData.ClassName = viewmodel.ClassName;
                classData.TotalCourseDays = viewmodel.TotalCourseDays;
                classData.contactedBy = viewmodel.ContactedBy;
                classData.ClassDescription = viewmodel.ClassDescription;
                classData.ClassStartData = CombinedDataTime;
                classData.UserName = userName;
                classData.UserId = viewmodel.UserId;
                classData.ApplicationUsers = viewmodel.ApplicationUsers;

                uow.ClassDataRepository.Update(classData);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var classData = uow.ClassDataRepository.GetById(id);
            ViewBag.UserName = uow.Context.Users.ToList();
            //ViewBag.UserName = uow.Context.Users.Select(x => x.UserName).ToList();
            var datatime = classData.ClassStartData;
            var ClassStartTime = Convert.ToDateTime(datatime.ToShortTimeString());
            var ClassStartDate = Convert.ToDateTime(datatime.ToShortDateString());
            ClassDataViewModel viewmodel = new ClassDataViewModel
            {
                Id = classData.Id,
                Title = classData.Title,
                ContactedBy = classData.contactedBy,
                Content = classData.Content,
                ClassName = classData.ClassName,
                TotalCourseDays = classData.TotalCourseDays,
                ClassDescription = classData.ClassDescription,
                UserName = classData.UserName,
                UserId = classData.UserId,
                ApplicationUsers = classData.ApplicationUsers,
                ClassStartData = ClassStartDate,
                ClassStartTime = ClassStartTime,
            };
            uow.ClassDataRepository.Remove(classData);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var classData = uow.ClassDataRepository.GetById(id);
            ViewBag.UserName = uow.Context.Users.ToList();
            //ViewBag.UserName = uow.Context.Users.Select(x => x.UserName).ToList();
            var datatime = classData.ClassStartData;
            var ClassStartTime = Convert.ToDateTime(datatime.ToShortTimeString());
            var ClassStartDate = Convert.ToDateTime(datatime.ToShortDateString());
            ClassDataViewModel viewmodel = new ClassDataViewModel
            {
                Id = classData.Id,
                Title = classData.Title,
                ContactedBy = classData.contactedBy,
                Content = classData.Content,
                ClassName = classData.ClassName,
                TotalCourseDays = classData.TotalCourseDays,
                ClassDescription = classData.ClassDescription,
                UserName = classData.UserName,
                UserId = classData.UserId,
                ApplicationUsers = classData.ApplicationUsers,
                ClassStartData = ClassStartDate,
                ClassStartTime = ClassStartTime,
            };

            return View(viewmodel);
        }
    }
}