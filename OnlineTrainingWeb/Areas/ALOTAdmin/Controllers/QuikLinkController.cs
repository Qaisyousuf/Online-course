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
    public class QuikLinkController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuikLinkController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuikLinkData()
        {
            var quikLinke = uow.QuiklinkRepository.GetAll();

            List<QuiklinkViewModel> viewmodel = new List<QuiklinkViewModel>();

            foreach (var item in quikLinke)
            {
                viewmodel.Add(new QuiklinkViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    IconUrl=item.IconUrl,
                    LinkUrl=item.LinkUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuiklinkViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuiklinkViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quikLink = new Quiklink
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    IconUrl=viewmodel.IconUrl,
                    LinkUrl=viewmodel.LinkUrl,
                };

                uow.QuiklinkRepository.Add(quikLink);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quikLink = uow.QuiklinkRepository.GetById(id);

            QuiklinkViewModel viewmodel = new QuiklinkViewModel
            {
                Id=quikLink.Id,
                MainTitle=quikLink.MainTitle,
                Title=quikLink.Title,
                IconUrl=quikLink.IconUrl,
                LinkUrl=quikLink.LinkUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuiklinkViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quikLink = uow.QuiklinkRepository.GetById(viewmodel.Id);

                quikLink.Id = viewmodel.Id;
                quikLink.MainTitle = viewmodel.MainTitle;
                quikLink.Title = viewmodel.Title;
                quikLink.IconUrl = viewmodel.IconUrl;
                quikLink.LinkUrl = viewmodel.LinkUrl;

                uow.QuiklinkRepository.Update(quikLink);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quikLink = uow.QuiklinkRepository.GetById(id);

            QuiklinkViewModel viewmodel = new QuiklinkViewModel
            {
                Id = quikLink.Id,
                MainTitle = quikLink.MainTitle,
                Title = quikLink.Title,
                IconUrl = quikLink.IconUrl,
                LinkUrl = quikLink.LinkUrl,
            };

            uow.QuiklinkRepository.Remove(quikLink);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quikLink = uow.QuiklinkRepository.GetById(id);

            QuiklinkViewModel viewmodel = new QuiklinkViewModel
            {
                Id = quikLink.Id,
                MainTitle = quikLink.MainTitle,
                Title = quikLink.Title,
                IconUrl = quikLink.IconUrl,
                LinkUrl = quikLink.LinkUrl,
            };

            return View(viewmodel);
        }
    }
}