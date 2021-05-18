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
    public class ThisProgramForWhoContentSectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public ThisProgramForWhoContentSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetThisProgramForContentSection()
        {
            var thisProgramForWho = uow.ThisProgramForWhoContentSectionRepository.GetAll();

            List<WhoIsThisProgramForContentSectionViewModel> viewmodel = new List<WhoIsThisProgramForContentSectionViewModel>();

            foreach (var item in thisProgramForWho)
            {
                viewmodel.Add(new WhoIsThisProgramForContentSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    VideoUrl=item.VideoUrl,
                    ReadMoreButton=item.ReadMoreButton,
                    ReadMoreButtonUrl=item.ReadMoreButtonUrl,
                    AnimationContent=item.AnimationContent,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhoIsThisProgramForContentSectionViewModel());
        }

        [HttpPost]
        public ActionResult Create(WhoIsThisProgramForContentSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whoisThisprograme = new WhoIsThisProgramForContentSection
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    VideoUrl=viewmodel.VideoUrl,
                    ReadMoreButton=viewmodel.ReadMoreButton,
                    ReadMoreButtonUrl=viewmodel.ReadMoreButtonUrl,
                    AnimationContent=viewmodel.AnimationContent,
                    Content=viewmodel.Content,
                };

                uow.ThisProgramForWhoContentSectionRepository.Add(whoisThisprograme);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whoisThisProgram = uow.ThisProgramForWhoContentSectionRepository.GetById(id);

            WhoIsThisProgramForContentSectionViewModel viewmodel = new WhoIsThisProgramForContentSectionViewModel
            {
                Id=whoisThisProgram.Id,
                MainTitle=whoisThisProgram.MainTitle,
                Content=whoisThisProgram.Content,
                VideoUrl=whoisThisProgram.VideoUrl,
                ReadMoreButton=whoisThisProgram.ReadMoreButton,
                ReadMoreButtonUrl=whoisThisProgram.ReadMoreButtonUrl,
                AnimationContent=whoisThisProgram.AnimationContent,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhoIsThisProgramForContentSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whoisThisProgram = uow.ThisProgramForWhoContentSectionRepository.GetById(viewmodel.Id);

                whoisThisProgram.Id = viewmodel.Id;
                whoisThisProgram.MainTitle = viewmodel.MainTitle;
                whoisThisProgram.Content = viewmodel.Content;
                whoisThisProgram.VideoUrl = viewmodel.VideoUrl;
                whoisThisProgram.ReadMoreButton = viewmodel.ReadMoreButton;
                whoisThisProgram.ReadMoreButtonUrl = viewmodel.ReadMoreButtonUrl;
                whoisThisProgram.AnimationContent = viewmodel.AnimationContent;

                uow.ThisProgramForWhoContentSectionRepository.Update(whoisThisProgram);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var whoIshthisProgram = uow.ThisProgramForWhoContentSectionRepository.GetById(id);

            WhoIsThisProgramForContentSectionViewModel viewmodoel = new WhoIsThisProgramForContentSectionViewModel
            {
                Id=whoIshthisProgram.Id,
                MainTitle=whoIshthisProgram.MainTitle,
                Content=whoIshthisProgram.Content,
                AnimationContent=whoIshthisProgram.AnimationContent,
                VideoUrl=whoIshthisProgram.VideoUrl,
                ReadMoreButton=whoIshthisProgram.ReadMoreButton,
                ReadMoreButtonUrl=whoIshthisProgram.ReadMoreButtonUrl,

            };

            uow.ThisProgramForWhoContentSectionRepository.Remove(whoIshthisProgram);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var whoisThisProgram = uow.ThisProgramForWhoContentSectionRepository.GetById(id);

            WhoIsThisProgramForContentSectionViewModel viewmodel = new WhoIsThisProgramForContentSectionViewModel
            {
                Id = whoisThisProgram.Id,
                MainTitle = whoisThisProgram.MainTitle,
                Content = whoisThisProgram.Content,
                VideoUrl = whoisThisProgram.VideoUrl,
                ReadMoreButton = whoisThisProgram.ReadMoreButton,
                ReadMoreButtonUrl = whoisThisProgram.ReadMoreButtonUrl,
                AnimationContent = whoisThisProgram.AnimationContent,
            };

            return View(viewmodel);
        }
    }
}