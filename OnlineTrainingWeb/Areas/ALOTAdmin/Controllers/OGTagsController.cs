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
    public class OGTagsController : Controller
    {
        private readonly IUnitOfWork uow;

        public OGTagsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOGTagData()
        {
            var ogTag = uow.OGTagsRepository.GetAll();

            List<OpenGraphMetaTagsViewModel> viewmodel = new List<OpenGraphMetaTagsViewModel>();

            foreach (var item in ogTag)
            {
                viewmodel.Add(new OpenGraphMetaTagsViewModel
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
            return View(new OpenGraphMetaTagsViewModel());
        }

        [HttpPost]
        public ActionResult Create(OpenGraphMetaTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ogTag = new OpenGraphMetaTags
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Content=viewmodel.Content,
                };
                uow.OGTagsRepository.Add(ogTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ogtag = uow.OGTagsRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id=ogtag.Id,
                Name=ogtag.Name,
                Content=ogtag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OpenGraphMetaTagsViewModel viemwodel)
        {
            if(ModelState.IsValid)
            {
                var ogtag = uow.OGTagsRepository.GetById(viemwodel.Id);

                ogtag.Id = viemwodel.Id;
                ogtag.Name = viemwodel.Name;
                ogtag.Content = viemwodel.Content;

                uow.OGTagsRepository.Update(ogtag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ogtag = uow.OGTagsRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id = ogtag.Id,
                Name = ogtag.Name,
                Content = ogtag.Content,
            };

            uow.OGTagsRepository.Remove(ogtag);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ogtag = uow.OGTagsRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id = ogtag.Id,
                Name = ogtag.Name,
                Content = ogtag.Content,
            };

            return View(viewmodel);
        }
    }
}