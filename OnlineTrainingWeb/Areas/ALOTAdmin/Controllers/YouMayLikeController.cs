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
    public class YouMayLikeController : Controller
    {
        private readonly IUnitOfWork uow;

        public YouMayLikeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetYouMayLikeData()
        {
            var youMayLike = uow.YouMayLikeRepository.GetAll();

            List<YouMayLikeViewModel> viewmodel = new List<YouMayLikeViewModel>();

            foreach (var item in youMayLike)
            {
                viewmodel.Add(new YouMayLikeViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Contetn=item.Contetn,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new YouMayLikeViewModel());
        }

        [HttpPost]
        public ActionResult Create(YouMayLikeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var youMayLike = new YouMayLike
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Contetn=viewmodel.Contetn,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.YouMayLikeRepository.Add(youMayLike);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var youMayLike = uow.YouMayLikeRepository.GetById(id);

            YouMayLikeViewModel viewmodel = new YouMayLikeViewModel
            {
                Id=youMayLike.Id,
                Title=youMayLike.Title,
                Contetn=youMayLike.Contetn,
                ImageUrl=youMayLike.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(YouMayLikeViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var youMayLike = uow.YouMayLikeRepository.GetById(viewmodel.Id);

                youMayLike.Id = viewmodel.Id;
                youMayLike.Title = viewmodel.Title;
                youMayLike.Contetn = viewmodel.Contetn;
                youMayLike.ImageUrl = viewmodel.ImageUrl;

                uow.YouMayLikeRepository.Update(youMayLike);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var youMayLik = uow.YouMayLikeRepository.GetById(id);

            YouMayLikeViewModel viewmodel = new YouMayLikeViewModel
            {
                Id=youMayLik.Id,
                Title=youMayLik.Title,
                Contetn=youMayLik.Contetn,
                ImageUrl=youMayLik.ImageUrl,
            };

            uow.YouMayLikeRepository.Remove(youMayLik);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var youMayLike = uow.YouMayLikeRepository.GetById(id);

            YouMayLikeViewModel viewmodel = new YouMayLikeViewModel
            {
                Id = youMayLike.Id,
                Title = youMayLike.Title,
                Contetn = youMayLike.Contetn,
                ImageUrl = youMayLike.ImageUrl,
            };

            return View(viewmodel);
        }

    }
}