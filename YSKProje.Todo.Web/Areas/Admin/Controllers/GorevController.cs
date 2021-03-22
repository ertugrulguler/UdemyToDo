using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.Todo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.Todo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GorevController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly IAciliyetService _aciliyetService;
        public GorevController(IGorevService gorevService, IAciliyetService aciliyetService)
        {
            _gorevService = gorevService;
            _aciliyetService = aciliyetService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "gorev";
            var gorevler = _gorevService.GetirHepsi();
            var models = new List<GorevListViewModel>();
            foreach (var gorev in gorevler)
            {
                var model = new GorevListViewModel()
                {
                    Aciklama = gorev.Aciklama,
                    Aciliyet = gorev.Aciliyet,
                    AciliyetId = gorev.AciliyetId,
                    Ad = gorev.Ad,
                    Durum = gorev.Durum,
                    Id = gorev.Id,
                    OlusturulmaTarih = gorev.OlusturulmaTarih
                };
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult EkleGorev()
        {
            TempData["Active"] = "gorev";
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View(new GorevAddViewModel());
        }

        [HttpPost]
        public IActionResult EkleGorev(GorevAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev
                {
                    Aciklama = model.Aciklama,
                    Ad = model.Ad,
                    AciliyetId = model.AciliyetId
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
