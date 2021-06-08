using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork _uow { get; set; }
        public BaseController()
        {

        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewResult result = filterContext.Result as ViewResult;

            if(result !=null)
            {
                BaseViewModel baseViewModel = ViewData.Model as BaseViewModel;

                if(baseViewModel !=null)
                {
                  

                    var site = _uow.Context.SiteSettings.FirstOrDefault();

                    var siteSettings = _uow.Context.SiteSettings.Where(x => x.Id == site.Id).FirstOrDefault();

                    baseViewModel.SiteName = siteSettings.SiteName;
                    baseViewModel.SiteTitle = siteSettings.SiteTitle;
                    baseViewModel.SiteOwner = siteSettings.SiteOwner;
                    baseViewModel.GoogleAnalytics = siteSettings.GoogleAnalytics;
                    baseViewModel.GoogleSiteVerification = siteSettings.GoogleSiteVerification;
                    baseViewModel.AnimationUrl = siteSettings.AnimationUrl;
                    baseViewModel.SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate;
                    baseViewModel.FooterLinksTag = baseViewModel.FooterLinksTag;

                    ViewBag.FooterTags = _uow.FooterLinksRepository.GetAll();



                  

                }
            }
        }
    }
}