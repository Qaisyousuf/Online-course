using Data.Interfaces;
using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class BuildBetterSkillsFasterController : Controller
    {
        private readonly IUnitOfWork uow;

        public BuildBetterSkillsFasterController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBuildBetterSkillsFasterData()
        {
            var buildBetterSkillFaster = uow.BuillBetterSkillsFasterRepository.GetAll();

            List<BuillBetterSkillsFasterViewModel> viewmodel = new List<BuillBetterSkillsFasterViewModel>();

            foreach (var item in buildBetterSkillFaster)
            {
                viewmodel.Add(new BuillBetterSkillsFasterViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    AnimatinUrl=item.AnimatinUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BuillBetterSkillsFasterViewModel());
        }

        [HttpPost]
        public ActionResult Create(BuillBetterSkillsFasterViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var builderBetterSkillsFaster = new BuillBetterSkillsFaster
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    AnimatinUrl=viewmodel.AnimatinUrl
                };

                uow.BuillBetterSkillsFasterRepository.Add(builderBetterSkillsFaster);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var buildBetterSkillsFaster = uow.BuillBetterSkillsFasterRepository.GetById(id);

            BuillBetterSkillsFasterViewModel viewmodel = new BuillBetterSkillsFasterViewModel
            {
                Id=buildBetterSkillsFaster.Id,
                MainTitle=buildBetterSkillsFaster.MainTitle,
                Title=buildBetterSkillsFaster.Title,
                AnimatinUrl=buildBetterSkillsFaster.AnimatinUrl,
                Content=buildBetterSkillsFaster.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(BuillBetterSkillsFasterViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var buildBetterSkillsFaster = uow.BuillBetterSkillsFasterRepository.GetById(viewmodel.Id);

                buildBetterSkillsFaster.Id = viewmodel.Id;
                buildBetterSkillsFaster.MainTitle = viewmodel.MainTitle;
                buildBetterSkillsFaster.Title = viewmodel.Title;
                buildBetterSkillsFaster.AnimatinUrl = viewmodel.AnimatinUrl;
                buildBetterSkillsFaster.Content = viewmodel.Content;

                uow.BuillBetterSkillsFasterRepository.Update(buildBetterSkillsFaster);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var buillBetterskillsFaster = uow.BuillBetterSkillsFasterRepository.GetById(id);

            BuillBetterSkillsFasterViewModel viewmodel = new BuillBetterSkillsFasterViewModel
            {
                Id=buillBetterskillsFaster.Id,
                MainTitle=buillBetterskillsFaster.MainTitle,
                Title=buillBetterskillsFaster.Title,
                Content=buillBetterskillsFaster.Content,
                AnimatinUrl=buillBetterskillsFaster.AnimatinUrl,
            };
            uow.BuillBetterSkillsFasterRepository.Remove(buillBetterskillsFaster);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var buildBetterSkillsFaster = uow.BuillBetterSkillsFasterRepository.GetById(id);

            BuillBetterSkillsFasterViewModel viewmodel = new BuillBetterSkillsFasterViewModel
            {
                Id = buildBetterSkillsFaster.Id,
                MainTitle = buildBetterSkillsFaster.MainTitle,
                Title = buildBetterSkillsFaster.Title,
                AnimatinUrl = buildBetterSkillsFaster.AnimatinUrl,
                Content = buildBetterSkillsFaster.Content,
            };

            return View(viewmodel);
        }
    }
}