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
    public class VideoReviewController : Controller
    {
        private readonly IUnitOfWork uow;

        public VideoReviewController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetVideoReviewData()
        {
            var videoReview = uow.VideoReviewRepository.GetAll();

            List<VideoReviewViewModel> viewmodel = new List<VideoReviewViewModel>();

            foreach (var item in videoReview)
            {
                viewmodel.Add(new VideoReviewViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    Name=item.Name,
                    CountryFlagUrl=item.CountryFlagUrl,
                    CountryName=item.CountryName,
                    VideoUrl=item.VideoUrl,
                    ProgramCompletionDate=item.ProgramCompletionDate,
                    ProgramImageUrl=item.ProgramImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new VideoReviewViewModel());
        }

        [HttpPost]
        public ActionResult Create(VideoReviewViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var videoReview = new VideoReview
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    Name=viewmodel.Name,
                    CountryFlagUrl=viewmodel.CountryFlagUrl,
                    CountryName=viewmodel.CountryName,
                    VideoUrl=viewmodel.VideoUrl,
                    ProgramCompletionDate=viewmodel.ProgramCompletionDate,
                    ProgramImageUrl=viewmodel.ProgramImageUrl,
                };

                uow.VideoReviewRepository.Add(videoReview);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var videoReview = uow.VideoReviewRepository.GetById(id);

            VideoReviewViewModel viewmodel = new VideoReviewViewModel
            {
                Id=videoReview.Id,
                MainTitle=videoReview.MainTitle,
                Content=videoReview.Content,
                Name=videoReview.Name,
                CountryFlagUrl=videoReview.CountryFlagUrl,
                CountryName=videoReview.CountryName,
                VideoUrl=videoReview.VideoUrl,
                ProgramCompletionDate=videoReview.ProgramCompletionDate,
                ProgramImageUrl=videoReview.ProgramImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(VideoReviewViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var videoReview = uow.VideoReviewRepository.GetById(viewmodel.Id);

                videoReview.Id = viewmodel.Id;
                videoReview.MainTitle = viewmodel.MainTitle;
                videoReview.Content = viewmodel.Content;
                videoReview.Name = viewmodel.Name;
                videoReview.CountryFlagUrl = viewmodel.CountryFlagUrl;
                videoReview.CountryName = viewmodel.CountryName;
                videoReview.VideoUrl = viewmodel.VideoUrl;
                videoReview.ProgramCompletionDate = viewmodel.ProgramCompletionDate;
                videoReview.ProgramImageUrl = viewmodel.ProgramImageUrl;

                uow.VideoReviewRepository.Update(videoReview);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var videoReview = uow.VideoReviewRepository.GetById(id);

            VideoReviewViewModel viewmodel = new VideoReviewViewModel
            {
                Id=videoReview.Id,
                MainTitle=videoReview.MainTitle,
                Content=videoReview.Content,
                Name=videoReview.Name,
                CountryFlagUrl=videoReview.CountryFlagUrl,
                CountryName=videoReview.CountryName,
                VideoUrl=videoReview.VideoUrl,
                ProgramCompletionDate=videoReview.ProgramCompletionDate,
                ProgramImageUrl=videoReview.ProgramImageUrl,
            };

            uow.VideoReviewRepository.Remove(videoReview);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var videoReview = uow.VideoReviewRepository.GetById(id);

            VideoReviewViewModel viewmodel = new VideoReviewViewModel
            {
                Id = videoReview.Id,
                MainTitle = videoReview.MainTitle,
                Content = videoReview.Content,
                Name = videoReview.Name,
                CountryFlagUrl = videoReview.CountryFlagUrl,
                CountryName = videoReview.CountryName,
                VideoUrl = videoReview.VideoUrl,
                ProgramCompletionDate = videoReview.ProgramCompletionDate,
                ProgramImageUrl = videoReview.ProgramImageUrl,
            };

            return View(viewmodel);
        }
    }
}