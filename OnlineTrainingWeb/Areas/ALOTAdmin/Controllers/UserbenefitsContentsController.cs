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
    public class UserbenefitsContentsController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserbenefitsContentsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserBenefitsContentsData()
        {
            var userBenefitsContents = uow.UserbenefitsContentsRepository.GetAll();

            List<UserbenefitsContentsViewModel> viewmodel = new List<UserbenefitsContentsViewModel>();

            foreach (var item in userBenefitsContents)
            {
                viewmodel.Add(new UserbenefitsContentsViewModel
                {
                    Id=item.Id,
                    Maintitle=item.Maintitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserbenefitsContentsViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserbenefitsContentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userBenefitsContents = new UserbenefitsContents
                {
                    Id=viewmodel.Id,
                    Maintitle=viewmodel.Maintitle,
                    Content=viewmodel.Content,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                };

                uow.UserbenefitsContentsRepository.Add(userBenefitsContents);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userBenefitsContents = uow.UserbenefitsContentsRepository.GetById(id);

            UserbenefitsContentsViewModel viewmodel = new UserbenefitsContentsViewModel
            {
                Id=userBenefitsContents.Id,
                Maintitle=userBenefitsContents.Maintitle,
                Content=userBenefitsContents.Content,
                ButtonText=userBenefitsContents.ButtonText,
                ButtonUrl=userBenefitsContents.ButtonUrl,
                
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserbenefitsContentsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userBenefitsContents = uow.UserbenefitsContentsRepository.GetById(viewmodel.Id);

                userBenefitsContents.Id = viewmodel.Id;
                userBenefitsContents.Maintitle = viewmodel.Maintitle;
                userBenefitsContents.Content = viewmodel.Content;
                userBenefitsContents.ButtonText = viewmodel.ButtonText;
                userBenefitsContents.ButtonUrl = viewmodel.ButtonUrl;

                uow.UserbenefitsContentsRepository.Update(userBenefitsContents);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userBenefitsContents = uow.UserbenefitsContentsRepository.GetById(id);

            UserbenefitsContentsViewModel viewmodel = new UserbenefitsContentsViewModel
            {
                Id=userBenefitsContents.Id,
                Maintitle=userBenefitsContents.Maintitle,
                Content=userBenefitsContents.Content,
                ButtonText=userBenefitsContents.ButtonText,
                ButtonUrl=userBenefitsContents.ButtonUrl,
            };

            uow.UserbenefitsContentsRepository.Remove(userBenefitsContents);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userBenefitsContents = uow.UserbenefitsContentsRepository.GetById(id);

            UserbenefitsContentsViewModel viewmodel = new UserbenefitsContentsViewModel
            {
                Id = userBenefitsContents.Id,
                Maintitle = userBenefitsContents.Maintitle,
                Content = userBenefitsContents.Content,
                ButtonText = userBenefitsContents.ButtonText,
                ButtonUrl = userBenefitsContents.ButtonUrl,

            };

            return View(viewmodel);
        }
    }
}