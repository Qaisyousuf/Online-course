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
    public class TwitterTagsController : Controller
    {
        private readonly IUnitOfWork uow;

        public TwitterTagsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTwitterTagsData()
        {
            var twitterTag = uow.TwitterTagRepository.GetAll();

            List<TwitterMetaTagsViewModel> viewmodel = new List<TwitterMetaTagsViewModel>();

            foreach (var item in twitterTag)
            {
                viewmodel.Add(new TwitterMetaTagsViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Content=item.Content,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new TwitterMetaTagsViewModel());

        }

        [HttpPost]
        public ActionResult Create(TwitterMetaTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var twitterTag = new TwitterMetaTags
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Content=viewmodel.Content,
                };

                uow.TwitterTagRepository.Add(twitterTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var twitterTag = uow.TwitterTagRepository.GetById(id);

            TwitterMetaTagsViewModel viewmodel = new TwitterMetaTagsViewModel
            {
                Id=twitterTag.Id,
                Name=twitterTag.Name,
                Content=twitterTag.Content,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TwitterMetaTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var twitterTag = uow.TwitterTagRepository.GetById(viewmodel.Id);

                twitterTag.Id = viewmodel.Id;
                twitterTag.Name = viewmodel.Name;
                twitterTag.Content = viewmodel.Content;

                uow.TwitterTagRepository.Update(twitterTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var twitterTag = uow.TwitterMetaTagsRepository.GetById(id);

        //    TwitterMetaTagsViewModel viewmodel = new TwitterMetaTagsViewModel
        //    {
        //        Id=twitterTag.Id,
        //        Name=twitterTag.Name,
        //        Content=twitterTag.Content,
        //    };

        //    return View (viewmodel);
        //}

        //[HttpPost]
        //public ActionResult Edit(TwitterMetaTagsViewModel viewmodel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var twitterTag = uow.TwitterMetaTagsRepository.GetById(viewmodel.Id);

        //        twitterTag.Id = viewmodel.Id;
        //        twitterTag.Name = viewmodel.Name;
        //        twitterTag.Content = viewmodel.Content;

        //        uow.TwitterMetaTagsRepository.Update(twitterTag);
        //        uow.Commit();
        //    }
        //    return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var twitterTag = uow.TwitterTagRepository.GetById(id);

            TwitterMetaTagsViewModel viewmodel = new TwitterMetaTagsViewModel
            {
                Id = twitterTag.Id,
                Name = twitterTag.Name,
                Content = twitterTag.Content,
            };

            uow.TwitterTagRepository.Remove(twitterTag);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var twitterTag = uow.TwitterTagRepository.GetById(id);

            TwitterMetaTagsViewModel viewmodel = new TwitterMetaTagsViewModel
            {
                Id = twitterTag.Id,
                Name = twitterTag.Name,
                Content = twitterTag.Content,
            };

            return View (viewmodel);
        }
    }
}