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
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSiteSettingsData()
        {
            var siteSettings = uow.SiteSettingrepository.GetAll();

            List<SiteSettingsViewmodel> viewmodel = new List<SiteSettingsViewmodel>();

            foreach (var item in siteSettings)
            {
                viewmodel.Add(new SiteSettingsViewmodel
                {
                    Id=item.Id,
                    SiteName=item.SiteName,
                    SiteOwner=item.SiteOwner,
                    SiteTitle=item.SiteTitle,
                    GoogleAnalytics=item.GoogleAnalytics,
                    GoogleSiteVerification=item.GoogleSiteVerification,
                    SiteLastUpdatedDate=item.SiteLastUpdatedDate,
                    AnimationUrl=item.AnimationUrl,
                    FooterLinks=item.FotterLinks,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
    }
}