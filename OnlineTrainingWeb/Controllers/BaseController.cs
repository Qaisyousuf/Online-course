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
    [HandleError]
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

                    var footerId = _uow.Context.FooterLinks.Select(x => x.Id).ToList();

                    var footerTag = _uow.Context.FooterLinks.Where(x => footerId.Contains(x.Id)).Select(x => x.NavigationName).ToList();
                    var site = _uow.Context.SiteSettings.FirstOrDefault();

                   
                    var siteSettings = _uow.Context.SiteSettings.Include("FotterLinks").FirstOrDefault();

                    baseViewModel.SiteName = siteSettings.SiteName;
                    baseViewModel.SiteTitle = siteSettings.SiteTitle;
                    baseViewModel.SiteOwner = siteSettings.SiteOwner;
                    baseViewModel.GoogleAnalytics = siteSettings.GoogleAnalytics;
                    baseViewModel.GoogleSiteVerification = siteSettings.GoogleSiteVerification;
                    baseViewModel.AnimationUrl = siteSettings.AnimationUrl;
                    baseViewModel.SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate;
                    baseViewModel.SiteContent = siteSettings.SiteContent;
                    baseViewModel.Sitecopyright = siteSettings.Sitecopyright;
                    baseViewModel.DesignedBy = siteSettings.DesignedBy;

                   

                    int[] footterLinksIt = siteSettings.FotterLinks.Select(x => x.Id).ToArray();

                    baseViewModel.FooterLinksId = footterLinksIt;

                    baseViewModel.FooterLinks = siteSettings.FotterLinks;

                    baseViewModel.FooterLinksTag = footerTag;
                   
                   


                }
            }
        }
    }
}