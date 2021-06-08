using Data.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class COVID19Controller : Controller
    {
        private readonly IUnitOfWork uow;

        public COVID19Controller(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCovid19Data()
        {
            var covid19 = uow.Covid19Repository.GetAll();

            List<COVID_19ViewModel> viewmodel = new List<COVID_19ViewModel>();

            foreach (var item in covid19)
            {
                viewmodel.Add(new COVID_19ViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new COVID_19ViewModel());
        }
        [HttpPost]
        public ActionResult Create(COVID_19ViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                COVID_19 covid = new COVID_19
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.Covid19Repository.Add(covid);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var covid = uow.Covid19Repository.GetById(id);

            COVID_19ViewModel viewmodel = new COVID_19ViewModel
            {
                Id=covid.Id,
                MainTitle=covid.MainTitle,
                Content=covid.Content,
                ImageUrl=covid.ImageUrl,

            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(COVID_19ViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var covid = uow.Covid19Repository.GetById(viewmodel.Id);

                covid.Id = viewmodel.Id;
                covid.MainTitle = viewmodel.MainTitle;
                covid.Content = viewmodel.Content;
                covid.ImageUrl = viewmodel.ImageUrl;

                uow.Covid19Repository.Update(covid);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var covid = uow.Covid19Repository.GetById(id);

            COVID_19ViewModel viewmodle = new COVID_19ViewModel
            {
                Id=covid.Id,
                MainTitle=covid.MainTitle,
                Content=covid.Content,
                ImageUrl=covid.ImageUrl,
            };

            uow.Covid19Repository.Remove(covid);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var covid = uow.Covid19Repository.GetById(id);

            COVID_19ViewModel viewmodel = new COVID_19ViewModel
            {
                Id = covid.Id,
                MainTitle = covid.MainTitle,
                Content = covid.Content,
                ImageUrl = covid.ImageUrl,

            };

            return View(viewmodel);
        }

    }
}