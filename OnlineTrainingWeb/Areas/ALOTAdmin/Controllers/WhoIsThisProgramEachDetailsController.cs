using Data.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class WhoIsThisProgramEachDetailsController : Controller
    {
        private readonly IUnitOfWork uow;

        public WhoIsThisProgramEachDetailsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWhoIsThisPorgramForEachDetails()
        {
            var whoIsThisProgramEachDetails = uow.WhoIsThisProgramForEachDetails.GetAll();

            List<WhoIsThisProgramForEachDetailsViewModel> viewmodel = new List<WhoIsThisProgramForEachDetailsViewModel>();

            foreach (var item in whoIsThisProgramEachDetails)
            {
                viewmodel.Add(new WhoIsThisProgramForEachDetailsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    IconUrl=item.IconUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhoIsThisProgramForEachDetailsViewModel());
        }

        [HttpPost]
        public ActionResult Create(WhoIsThisProgramForEachDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whoisThisProgramDetails = new WhoIsThisProgramForEachDetails
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    IconUrl=viewmodel.IconUrl,
                };

                uow.WhoIsThisProgramForEachDetails.Add(whoisThisProgramDetails);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whoisThisProgramDetails = uow.WhoIsThisProgramForEachDetails.GetById(id);

            WhoIsThisProgramForEachDetailsViewModel viewmodel = new WhoIsThisProgramForEachDetailsViewModel
            {
                Id=whoisThisProgramDetails.Id,
                MainTitle=whoisThisProgramDetails.MainTitle,
                Content=whoisThisProgramDetails.Content,
                IconUrl=whoisThisProgramDetails.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhoIsThisProgramForEachDetailsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whoisthisprogram = uow.WhoIsThisProgramForEachDetails.GetById(viewmodel.Id);

                whoisthisprogram.Id = viewmodel.Id;
                whoisthisprogram.MainTitle = viewmodel.MainTitle;
                whoisthisprogram.IconUrl = viewmodel.IconUrl;
                whoisthisprogram.Content = viewmodel.Content;

                uow.WhoIsThisProgramForEachDetails.Update(whoisthisprogram);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
       public ActionResult Delete(int id)
       {
            var whoisThisProgramDetails = uow.WhoIsThisProgramForEachDetails.GetById(id);

            WhoIsThisProgramForEachDetailsViewModel viewmodel = new WhoIsThisProgramForEachDetailsViewModel
            {
                Id = whoisThisProgramDetails.Id,
                MainTitle = whoisThisProgramDetails.MainTitle,
                Content = whoisThisProgramDetails.Content,
                IconUrl = whoisThisProgramDetails.IconUrl,
            };

            uow.WhoIsThisProgramForEachDetails.Remove(whoisThisProgramDetails);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var whoisThisProgramDetails = uow.WhoIsThisProgramForEachDetails.GetById(id);

            WhoIsThisProgramForEachDetailsViewModel viewmodel = new WhoIsThisProgramForEachDetailsViewModel
            {
                Id = whoisThisProgramDetails.Id,
                MainTitle = whoisThisProgramDetails.MainTitle,
                Content = whoisThisProgramDetails.Content,
                IconUrl = whoisThisProgramDetails.IconUrl,
            };

            return View(viewmodel);
        }
    }
}