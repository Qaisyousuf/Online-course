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
    public class ITSkillGapImpactOnbusinessController : Controller
    {
        private readonly IUnitOfWork uow;

        public ITSkillGapImpactOnbusinessController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetITSkillsImpactOnbusiness()
        {
            var itSkillsImgactOnBusiness = uow.ITSkillsGapImpactsOnBusiness.GetAll();

            List<ITSkillsGapImpactsOnBusinessViewModel> viewmodel = new List<ITSkillsGapImpactsOnBusinessViewModel>();

            foreach (var item in itSkillsImgactOnBusiness)
            {
                viewmodel.Add(new ITSkillsGapImpactsOnBusinessViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.MainTitle,
                    Button=item.MainTitle,
                    ButtonUrl=item.MainTitle,
                    AnimationUrl=item.MainTitle,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ITSkillsGapImpactsOnBusinessViewModel());
        }

        [HttpPost]
        public ActionResult Create(ITSkillsGapImpactsOnBusinessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var itSkillsGapImpactOnBusiness = new ITSkillsGapImpactsOnBusiness
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    Button=viewmodel.Button,
                    ButtonUrl=viewmodel.ButtonUrl,
                    AnimationUrl=viewmodel.AnimationUrl,
                };

                uow.ITSkillsGapImpactsOnBusiness.Add(itSkillsGapImpactOnBusiness);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var itSkillImpactOnbusiness = uow.ITSkillsGapImpactsOnBusiness.GetById(id);

            ITSkillsGapImpactsOnBusinessViewModel viewmodel = new ITSkillsGapImpactsOnBusinessViewModel
            {
                Id=itSkillImpactOnbusiness.Id,
                MainTitle=itSkillImpactOnbusiness.MainTitle,
                Content=itSkillImpactOnbusiness.Content,
                Button=itSkillImpactOnbusiness.Button,
                ButtonUrl=itSkillImpactOnbusiness.ButtonUrl,
                AnimationUrl=itSkillImpactOnbusiness.AnimationUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ITSkillsGapImpactsOnBusinessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var itSkillImpactOnBusiness = uow.ITSkillsGapImpactsOnBusiness.GetById(viewmodel.Id);

                itSkillImpactOnBusiness.Id = viewmodel.Id;
                itSkillImpactOnBusiness.MainTitle = viewmodel.MainTitle;
                itSkillImpactOnBusiness.Content = viewmodel.Content;
                itSkillImpactOnBusiness.Button = viewmodel.Button;
                itSkillImpactOnBusiness.ButtonUrl = viewmodel.ButtonUrl;
                itSkillImpactOnBusiness.AnimationUrl = viewmodel.AnimationUrl;

                uow.ITSkillsGapImpactsOnBusiness.Update(itSkillImpactOnBusiness);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var itSkillImpactOnbusiness = uow.ITSkillsGapImpactsOnBusiness.GetById(id);

            ITSkillsGapImpactsOnBusinessViewModel viewmodel = new ITSkillsGapImpactsOnBusinessViewModel
            {
                Id = itSkillImpactOnbusiness.Id,
                MainTitle = itSkillImpactOnbusiness.MainTitle,
                Content = itSkillImpactOnbusiness.Content,
                Button = itSkillImpactOnbusiness.Button,
                ButtonUrl = itSkillImpactOnbusiness.ButtonUrl,
                AnimationUrl = itSkillImpactOnbusiness.AnimationUrl,
            };

            uow.ITSkillsGapImpactsOnBusiness.Remove(itSkillImpactOnbusiness);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var itSkillImpactOnbusiness = uow.ITSkillsGapImpactsOnBusiness.GetById(id);

            ITSkillsGapImpactsOnBusinessViewModel viewmodel = new ITSkillsGapImpactsOnBusinessViewModel
            {
                Id = itSkillImpactOnbusiness.Id,
                MainTitle = itSkillImpactOnbusiness.MainTitle,
                Content = itSkillImpactOnbusiness.Content,
                Button = itSkillImpactOnbusiness.Button,
                ButtonUrl = itSkillImpactOnbusiness.ButtonUrl,
                AnimationUrl = itSkillImpactOnbusiness.AnimationUrl,
            };

            return View(viewmodel);
        }
    }
}