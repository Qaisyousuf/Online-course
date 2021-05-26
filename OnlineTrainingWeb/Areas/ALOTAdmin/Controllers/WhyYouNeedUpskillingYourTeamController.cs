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
    public class WhyYouNeedUpskillingYourTeamController : Controller
    {
        private readonly IUnitOfWork uow;

        public WhyYouNeedUpskillingYourTeamController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWhyYouNeedUpSkillingYourTeamData()
        {
            var whyYouNeedUpSkillingYourTeam = uow.WhyYouNeedUpskillingYourTeamRepository.GetAll();

            List<WhyYouNeedUpskillingYourTeamViewModel> viewmodel = new List<WhyYouNeedUpskillingYourTeamViewModel>();

            foreach (var item in whyYouNeedUpSkillingYourTeam)
            {
                viewmodel.Add(new WhyYouNeedUpskillingYourTeamViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhyYouNeedUpskillingYourTeamViewModel());
        }

        [HttpPost]
        public ActionResult Create(WhyYouNeedUpskillingYourTeamViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyYouNeedUpSkillingYourTeam = new WhyYouNeedUpskillingYourTeam
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    AnimationUrl=viewmodel.AnimationUrl,
                };

                uow.WhyYouNeedUpskillingYourTeamRepository.Add(whyYouNeedUpSkillingYourTeam);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whyYouNeedUpSkillingYourTeam = uow.WhyYouNeedUpskillingYourTeamRepository.GetById(id);

            WhyYouNeedUpskillingYourTeamViewModel viewmodel = new WhyYouNeedUpskillingYourTeamViewModel
            {
                Id=whyYouNeedUpSkillingYourTeam.Id,
                MainTitle=whyYouNeedUpSkillingYourTeam.MainTitle,
                Content=whyYouNeedUpSkillingYourTeam.Content,
                AnimationUrl=whyYouNeedUpSkillingYourTeam.AnimationUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhyYouNeedUpskillingYourTeamViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whyYouNeedUpSkillingYourteam = uow.WhyYouNeedUpskillingYourTeamRepository.GetById(viewmodel.Id);

                whyYouNeedUpSkillingYourteam.Id = viewmodel.Id;
                whyYouNeedUpSkillingYourteam.MainTitle = viewmodel.MainTitle;
                whyYouNeedUpSkillingYourteam.Content = viewmodel.Content;
                whyYouNeedUpSkillingYourteam.AnimationUrl = viewmodel.AnimationUrl;

                uow.WhyYouNeedUpskillingYourTeamRepository.Update(whyYouNeedUpSkillingYourteam);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var whyYouNeedUpSkillingYourTeam = uow.WhyYouNeedUpskillingYourTeamRepository.GetById(id);

            WhyYouNeedUpskillingYourTeamViewModel viewmodel = new WhyYouNeedUpskillingYourTeamViewModel
            {
                Id = whyYouNeedUpSkillingYourTeam.Id,
                MainTitle = whyYouNeedUpSkillingYourTeam.MainTitle,
                Content = whyYouNeedUpSkillingYourTeam.Content,
                AnimationUrl = whyYouNeedUpSkillingYourTeam.AnimationUrl,
            };

            uow.WhyYouNeedUpskillingYourTeamRepository.Remove(whyYouNeedUpSkillingYourTeam);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var whyYouNeedUpSkillingYourTeam = uow.WhyYouNeedUpskillingYourTeamRepository.GetById(id);

            WhyYouNeedUpskillingYourTeamViewModel viewmodel = new WhyYouNeedUpskillingYourTeamViewModel
            {
                Id = whyYouNeedUpSkillingYourTeam.Id,
                MainTitle = whyYouNeedUpSkillingYourTeam.MainTitle,
                Content = whyYouNeedUpSkillingYourTeam.Content,
                AnimationUrl = whyYouNeedUpSkillingYourTeam.AnimationUrl,
            };
            return View(viewmodel);
        }
    }
}