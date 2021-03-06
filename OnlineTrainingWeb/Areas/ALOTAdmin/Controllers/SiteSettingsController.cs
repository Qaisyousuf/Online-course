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
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var siteSettings = uow.SiteSettingrepository.GetAll("FotterLinks").ToList();

            List<SiteSettingsViewmodel> viewmodel = new List<SiteSettingsViewmodel>();

            foreach (var item in siteSettings)
            {
                var footerIds = item.FotterLinks.Select(x => x.Id).ToList();

                var tagName = uow.Context.FooterLinks.Where(x => footerIds.Contains(x.Id)).Select(x => x.NavigationName).ToList();
                viewmodel.Add(new SiteSettingsViewmodel
                {
                    Id=item.Id,
                    SiteTitle =item.SiteTitle,
                    SiteName =item.SiteName,
                    SiteOwner=item.SiteOwner,
                    SiteLastUpdatedDate=item.SiteLastUpdatedDate,
                    GoogleAnalytics=item.GoogleAnalytics,
                    GoogleSiteVerification=item.GoogleSiteVerification,
                    AnimationUrl=item.AnimationUrl,
                    SiteContent=item.SiteContent,
                    DesignedBy=item.DesignedBy,
                    Sitecopyright=item.Sitecopyright,
                    FooterLinksTag = tagName,
                });
            }
            return View(viewmodel);
        }

        private void GetFootersData()
        {
            ViewBag.FooterData = uow.FooterLinksRepository.GetAll();
        }

        //[HttpGet]
        //public ActionResult GetSiteSettingsData()
        //{
        //    var siteSettings = uow.SiteSettingrepository.GetAll("FooterLinks");

        //    List<SiteSettingsViewmodel> viewmodel = new List<SiteSettingsViewmodel>();

        //    foreach (var item in siteSettings)
        //    {
        //        viewmodel.Add(new SiteSettingsViewmodel
        //        {
        //            Id=item.Id,
        //            SiteName=item.SiteName,
        //            SiteOwner=item.SiteOwner,
        //            SiteTitle=item.SiteTitle,
        //            GoogleAnalytics=item.GoogleAnalytics,
        //            GoogleSiteVerification=item.GoogleSiteVerification,
        //            SiteLastUpdatedDate=item.SiteLastUpdatedDate,
        //            AnimationUrl=item.AnimationUrl,
        //            FooterLinks=item.FotterLinks,
        //            FooterId=item.Id,
        //        });
        //    }

        //    return View(viewmodel);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FooterData = uow.FooterLinksRepository.GetAll();

            return View(new SiteSettingsViewmodel());
        }

        [HttpPost]
        public ActionResult Create(SiteSettingsViewmodel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var siteSettings = new SiteSettings
                {
                    Id=viewmodel.Id,
                    SiteTitle=viewmodel.SiteTitle,
                    SiteName=viewmodel.SiteName,
                    SiteOwner=viewmodel.SiteOwner,
                    GoogleSiteVerification=viewmodel.GoogleSiteVerification,
                    GoogleAnalytics=viewmodel.GoogleAnalytics,
                    SiteLastUpdatedDate=DateTime.Now,
                    AnimationUrl=viewmodel.AnimationUrl,
                    SiteContent=viewmodel.SiteContent,
                    Sitecopyright=viewmodel.Sitecopyright,
                    DesignedBy=viewmodel.DesignedBy,
                    FotterLinks=viewmodel.FooterLinks,
                };

                foreach (int linkstagIs in viewmodel.FooterLinksId)
                {
                    var footerlinkstag = uow.FooterLinksRepository.GetById(linkstagIs);
                    siteSettings.FotterLinks.Add(footerlinkstag);
                    
                }

                uow.SiteSettingrepository.Add(siteSettings);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var siteSetting = uow.Context.SiteSettings.Include("FotterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingsViewmodel viewmodel = new SiteSettingsViewmodel
            {
                SiteTitle=siteSetting.SiteTitle,
                SiteName=siteSetting.SiteName,
                SiteOwner=siteSetting.SiteOwner,
                GoogleAnalytics=siteSetting.GoogleAnalytics,
                GoogleSiteVerification=siteSetting.GoogleSiteVerification,
                AnimationUrl=siteSetting.AnimationUrl,
                SiteContent=siteSetting.SiteContent,
                Sitecopyright=siteSetting.Sitecopyright,
                DesignedBy=siteSetting.DesignedBy,

            };

            int[] footerlinksId = siteSetting.FotterLinks.Select(x=>x.Id).ToArray();

            viewmodel.FooterLinksId = footerlinksId;
            GetFootersData();
            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,SiteTitle,SiteName,SiteOwner,GoogleSiteVerification,GoogleAnalytics,SiteLastUpdatedDate,AnimationUrl,SiteContent,DesignedBy,Sitecopyright")] SiteSettingsViewmodel viewmodel,int[] FooterlinksId)
        {
            if(ModelState.IsValid)
            {
                var siteSettings = uow.Context.SiteSettings.Include("FotterLinks").SingleOrDefault(x => x.Id == viewmodel.Id);

                siteSettings.Id = viewmodel.Id;
                siteSettings.SiteName = viewmodel.SiteName;
                siteSettings.SiteTitle = viewmodel.SiteTitle;
                siteSettings.SiteOwner = viewmodel.SiteOwner;
                siteSettings.GoogleAnalytics = viewmodel.GoogleAnalytics;
                siteSettings.GoogleSiteVerification = viewmodel.GoogleSiteVerification;
                siteSettings.SiteContent = viewmodel.SiteContent;
                siteSettings.Sitecopyright = viewmodel.Sitecopyright;
                siteSettings.DesignedBy = viewmodel.DesignedBy;

                siteSettings.AnimationUrl = viewmodel.AnimationUrl;
                siteSettings.SiteLastUpdatedDate = DateTime.Now;

                var footerLinksaAdded = uow.Context.FooterLinks.Where(x => FooterlinksId.Contains(x.Id)).ToList();

                siteSettings.FotterLinks.Clear();

                foreach (var item in footerLinksaAdded)
                {
                    siteSettings.FotterLinks.Add(item);
                }

                uow.SiteSettingrepository.Update(siteSettings);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var siteSetting = uow.Context.SiteSettings.Include("FotterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingsViewmodel viewmodel = new SiteSettingsViewmodel
            {
                SiteTitle = siteSetting.SiteTitle,
                SiteName = siteSetting.SiteName,
                SiteOwner = siteSetting.SiteOwner,
                GoogleAnalytics = siteSetting.GoogleAnalytics,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                AnimationUrl = siteSetting.AnimationUrl,
                SiteContent=siteSetting.SiteContent,
                DesignedBy=siteSetting.DesignedBy,
                Sitecopyright=siteSetting.Sitecopyright,
            };

            int[] footerlinksId = siteSetting.FotterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerlinksId;
            GetFootersData();
            return View(viewmodel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult  DeleteConfirm(int id)
        {
            var siteSetting = uow.Context.SiteSettings.Include("FotterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingsViewmodel viewmodel = new SiteSettingsViewmodel
            {
                SiteTitle = siteSetting.SiteTitle,
                SiteName = siteSetting.SiteName,
                SiteOwner = siteSetting.SiteOwner,
                GoogleAnalytics = siteSetting.GoogleAnalytics,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                AnimationUrl = siteSetting.AnimationUrl,
                SiteContent=siteSetting.SiteContent,
                Sitecopyright=siteSetting.Sitecopyright,
                DesignedBy=siteSetting.DesignedBy,
            };

            int[] footerlinksId = siteSetting.FotterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerlinksId;

            GetFootersData();
            uow.SiteSettingrepository.Remove(siteSetting);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var siteSetting = uow.Context.SiteSettings.Include("FotterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingsViewmodel viewmodel = new SiteSettingsViewmodel
            {
                SiteTitle = siteSetting.SiteTitle,
                SiteName = siteSetting.SiteName,
                SiteOwner = siteSetting.SiteOwner,
                GoogleAnalytics = siteSetting.GoogleAnalytics,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                AnimationUrl = siteSetting.AnimationUrl,
                SiteContent=siteSetting.SiteContent,
                Sitecopyright=siteSetting.Sitecopyright,
                DesignedBy=siteSetting.DesignedBy,
            };

            int[] footerlinksId = siteSetting.FotterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerlinksId;
            GetFootersData();
            return View(viewmodel);
        }
    }
}