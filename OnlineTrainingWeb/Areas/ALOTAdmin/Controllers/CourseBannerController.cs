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
    public class CourseBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public CourseBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCourseBannerData()
        {
            var courseBanner = uow.CourseBannerRepository.GetAll();

            List<CourseBannerViewModel> viewmodel = new List<CourseBannerViewModel>();

            foreach (var item in courseBanner)
            {
                viewmodel.Add(new CourseBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                    SubContent=item.SubContent,
                    Content=item.Content,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CourseBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(CourseBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseBanner = new CourseBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonTUrl=viewmodel.DiscoverButtonTUrl,
                    SubContent=viewmodel.SubContent,
                    Content=viewmodel.Content,
                };

                uow.CourseBannerRepository.Add(courseBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var courseBanner = uow.CourseBannerRepository.GetById(id);

            CourseBannerViewModel viewmodel = new CourseBannerViewModel
            {
                Id=courseBanner.Id,
                MainTitle=courseBanner.MainTitle,
                SubTitle=courseBanner.SubTitle,
                ImageUrl=courseBanner.ImageUrl,
                JoinButton=courseBanner.JoinButton,
                JoinButtonUrl=courseBanner.JoinButtonUrl,
                DiscoverButton=courseBanner.DiscoverButton,
                DiscoverButtonTUrl=courseBanner.DiscoverButtonTUrl,
                Content=courseBanner.Content,
                SubContent=courseBanner.SubContent,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CourseBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var courseBanner = uow.CourseBannerRepository.GetById(viewmodel.Id);

                courseBanner.Id = viewmodel.Id;
                courseBanner.MainTitle = viewmodel.MainTitle;
                courseBanner.SubTitle = viewmodel.SubTitle;
                courseBanner.ImageUrl = viewmodel.ImageUrl;
                courseBanner.JoinButton = viewmodel.JoinButton;
                courseBanner.JoinButtonUrl = viewmodel.JoinButtonUrl;
                courseBanner.DiscoverButton = viewmodel.DiscoverButton;
                courseBanner.DiscoverButtonTUrl = viewmodel.DiscoverButtonTUrl;
                courseBanner.SubContent = viewmodel.SubContent;
                courseBanner.Content = viewmodel.Content;

                uow.CourseBannerRepository.Update(courseBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var courseBanner = uow.CourseBannerRepository.GetById(id);

            CourseBannerViewModel viewmodel = new CourseBannerViewModel
            {
                Id=courseBanner.Id,
                MainTitle=courseBanner.MainTitle,
                SubTitle=courseBanner.SubTitle,
                ImageUrl=courseBanner.ImageUrl,
                JoinButton=courseBanner.JoinButton,
                JoinButtonUrl=courseBanner.JoinButtonUrl,
                DiscoverButton=courseBanner.DiscoverButton,
                DiscoverButtonTUrl=courseBanner.DiscoverButtonTUrl,
                Content=courseBanner.Content,
                SubContent=courseBanner.SubContent,
            };

            uow.CourseBannerRepository.Remove(courseBanner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseBanner = uow.CourseBannerRepository.GetById(id);

            CourseBannerViewModel viewmodel = new CourseBannerViewModel
            {
                Id = courseBanner.Id,
                MainTitle = courseBanner.MainTitle,
                SubTitle = courseBanner.SubTitle,
                ImageUrl = courseBanner.ImageUrl,
                JoinButton = courseBanner.JoinButton,
                JoinButtonUrl = courseBanner.JoinButtonUrl,
                DiscoverButton = courseBanner.DiscoverButton,
                DiscoverButtonTUrl = courseBanner.DiscoverButtonTUrl,
                Content=courseBanner.Content,
                SubContent=courseBanner.SubContent,
            };

            return View(viewmodel);
        }
    }
}