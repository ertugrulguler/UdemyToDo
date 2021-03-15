using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YSKProje.Todo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.Todo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AciliyetController : Controller
    {
        private readonly IAciliyetService _aciliyetService;
        public AciliyetController(IAciliyetService aciliyetService)
        {
            _aciliyetService = aciliyetService;
        }
        public IActionResult Index()
        {
            var aciliyetList = _aciliyetService.GetirHepsi();

            var model = new List<AciliyetListVieewModel>();
            foreach (var item in aciliyetList)
            {
                var aciliyet = new AciliyetListVieewModel()
                {
                    Id = item.Id,
                    Tanim = item.Tanim
                };
                model.Add(aciliyet);
            }
            return View(model);
        }

        public IActionResult EkleAciliyet()
        {
            return View(new AciliyetAddViewModel());
        }

        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Kaydet(new Aciliyet() { Tanim = model.Tanim });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleAciliyet(int id)
        {
            var aciliyet = _aciliyetService.GetirIdile(id);

            var model = new AciliyetUpdateViewModel()
            {
                Id = aciliyet.Id,
                Tanim = aciliyet.Tanim
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Guncelle(new Aciliyet()
                {
                    Id = model.Id,
                    Tanim = model.Tanim
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
