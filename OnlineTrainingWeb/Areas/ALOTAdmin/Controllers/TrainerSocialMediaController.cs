using Data.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class TrainerSocialMediaController : Controller
    {
        private readonly IUnitOfWork uow;

        public TrainerSocialMediaController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTraienrSocialMedia()
        {
            var trainerSocialMediai = uow.TrainerSocialMediaRepository.GetAll();

            List<TrainerSocialMediaViewModel> viewmodel = new List<TrainerSocialMediaViewModel>();

            foreach (var item in trainerSocialMediai)
            {
                viewmodel.Add(new TrainerSocialMediaViewModel
                {
                    Id=item.Id,
                    SocialMediaIconUrl=item.SocialMediaIconUrl,
                    SocialMediaProfileUrl=item.SocialMediaProfileUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TrainerSocialMediaViewModel());
        }

        [HttpPost]
        public ActionResult Create(TrainerSocialMediaViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerSocialMedia = new TrainerSocialMedia
                {
                    Id=viewmodel.Id,
                    SocialMediaIconUrl=viewmodel.SocialMediaIconUrl,
                    SocialMediaProfileUrl=viewmodel.SocialMediaProfileUrl,
                };
                uow.TrainerSocialMediaRepository.Add(trainerSocialMedia);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var traienrSocialMedia = uow.TrainerSocialMediaRepository.GetById(id);

            TrainerSocialMediaViewModel viewmodel = new TrainerSocialMediaViewModel
            {
                Id=traienrSocialMedia.Id,
                SocialMediaIconUrl=traienrSocialMedia.SocialMediaIconUrl,
                SocialMediaProfileUrl=traienrSocialMedia.SocialMediaProfileUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TrainerSocialMediaViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerSocialMedia = uow.TrainerSocialMediaRepository.GetById(viewmodel.Id);

                trainerSocialMedia.Id = viewmodel.Id;
                trainerSocialMedia.SocialMediaIconUrl = viewmodel.SocialMediaIconUrl;
                trainerSocialMedia.SocialMediaProfileUrl = viewmodel.SocialMediaProfileUrl;

                uow.TrainerSocialMediaRepository.Update(trainerSocialMedia);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var trainerSocialMedia = uow.TrainerSocialMediaRepository.GetById(id);

            TrainerSocialMediaViewModel viewmodle = new TrainerSocialMediaViewModel
            {
                Id=trainerSocialMedia.Id,
                SocialMediaIconUrl=trainerSocialMedia.SocialMediaIconUrl,
                SocialMediaProfileUrl=trainerSocialMedia.SocialMediaProfileUrl,
            };

            uow.TrainerSocialMediaRepository.Remove(trainerSocialMedia);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var traienrSocialMedia = uow.TrainerSocialMediaRepository.GetById(id);

            TrainerSocialMediaViewModel viewmodel = new TrainerSocialMediaViewModel
            {
                Id = traienrSocialMedia.Id,
                SocialMediaIconUrl = traienrSocialMedia.SocialMediaIconUrl,
                SocialMediaProfileUrl = traienrSocialMedia.SocialMediaProfileUrl,
            };

            return View(viewmodel);
        }
    }
}