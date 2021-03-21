using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTrainingWeb.ViewModel;
using Data.Interfaces;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class HomeBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetHomeBanner()
        {
            var _HomeBanner = uow.HomeBannerRepository.GetAll();

            List<HomeBannerViewModel> viewmodel = new List<HomeBannerViewModel>();

            foreach (var item in _HomeBanner)
            {
                viewmodel.Add(new HomeBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonUrl=item.DiscoverButton,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
          return View(new HomeBannerViewModel());
        }
    }
}