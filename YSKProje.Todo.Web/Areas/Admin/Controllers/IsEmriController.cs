using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.Todo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Business.Interfaces;

namespace YSKProje.Todo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "isemri";
            var gorevler = _gorevService.GetirTumTablolarla();
            var models = new List<GorevListAllViewModel>();

            foreach (var item in gorevler)
            {
                var model = new GorevListAllViewModel()
                {
                    Id = item.Id,
                    Aciklama = item.Aciklama,
                    Aciliyet = item.Aciliyet,
                    Ad = item.Ad,
                    AppUser = item.AppUser,
                    OlusturulmaTarih = item.OlusturulmaTarih,
                    Raporlar = item.Raporlar
                };
                models.Add(model);
            }

            return View(models);
        }
    }
}
