using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Model;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    
    public class OurVisionController : Controller
    {
        private readonly IUnitOfWork uow;

        public OurVisionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/OurVision
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOurVisionData()
        {
            var ourVision = uow.OurVisionRepository.GetAll();

            List<OurVisionViewModel> viewmodel = new List<OurVisionViewModel>();

            foreach (var item in ourVision)
            {
                viewmodel.Add(new OurVisionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new OurVisionViewModel());
        }

        [HttpPost]
        public ActionResult Create(OurVisionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                OurVision ourVision = new OurVision
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };
                uow.OurVisionRepository.Add(ourVision);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ourVision = uow.OurVisionRepository.GetById(id);

            OurVisionViewModel viewmodoel = new OurVisionViewModel
            {
                Id=ourVision.Id,
                MainTitle=ourVision.MainTitle,
                ButtonText=ourVision.ButtonText,
                ButtonUrl=ourVision.ButtonUrl,
                Content=ourVision.Content,
                ImageUrl=ourVision.ImageUrl,

            };

            return View(viewmodoel);
        }

        [HttpPost]
        public ActionResult Edit(OurVisionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ourVision = uow.OurVisionRepository.GetById(viewmodel.Id);

                ourVision.Id = viewmodel.Id;
                ourVision.MainTitle = viewmodel.MainTitle;
                ourVision.ButtonText = viewmodel.ButtonText;
                ourVision.ButtonUrl = viewmodel.ButtonUrl;
                ourVision.Content = viewmodel.Content;
                ourVision.ImageUrl = viewmodel.ImageUrl;

                uow.OurVisionRepository.Update(ourVision);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ourVision = uow.OurVisionRepository.GetById(id);

            OurVisionViewModel viewmodel = new OurVisionViewModel
            {
                Id = ourVision.Id,
                MainTitle = ourVision.MainTitle,
                ButtonText=ourVision.ButtonText,
                ButtonUrl=ourVision.ButtonUrl,
                Content=ourVision.Content,
                ImageUrl=ourVision.ImageUrl,
            };

            uow.OurVisionRepository.Remove(ourVision);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ourVision = uow.OurVisionRepository.GetById(id);

            OurVisionViewModel viewmodel = new OurVisionViewModel
            {
                Id=ourVision.Id,
                MainTitle=ourVision.MainTitle,
                ButtonText=ourVision.ButtonText,
                ButtonUrl=ourVision.ButtonUrl,
                Content=ourVision.Content,
                ImageUrl=ourVision.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}