using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YSKProje.Todo.Web.Areas.Admin.Models;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.Todo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
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

        public IActionResult AtaPersonel(int id, string q, int sayfa = 1)
        {
            TempData["Active"] = "isemri";
            ViewBag.AktifSayfa = sayfa;
            //ViewBag.ToplamSayfa = (int)Math.Ceiling((double)_appUserService.GetirAdminOlmayanlar().Count / 3);

            int toplamSayfa;
            var gorev = _gorevService.GetirAciliyetIdIle(id);

            var personeller = _appUserService.GetirAdminOlmayanlar(out toplamSayfa, q, sayfa);

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.Aranan = q;
            var appUserListModel = new List<AppUserListViewModel>();

            foreach (var item in personeller)
            {
                var model = new AppUserListViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Email = item.Email,
                    Picture = item.Picture
                };

                appUserListModel.Add(model);
            }


            ViewBag.Personeller = appUserListModel;

            var gorevModel = new GorevListViewModel()
            {
                Id = gorev.Id,
                Aciklama = gorev.Aciklama,
                Aciliyet = gorev.Aciliyet,
                Ad = gorev.Ad,
                OlusturulmaTarih = gorev.OlusturulmaTarih
            };

            return View(gorevModel);
        }

        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirViewModel model)
        {
            var gorev = _gorevService.GetirIdile(model.GorevId);
            gorev.AppUserId = model.PersonelId;
            _gorevService.Guncelle(gorev);
            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirViewModel model)
        {
            TempData["Active"] = "isemri";
            var user = _userManager.Users.FirstOrDefault(i => i.Id == model.PersonelId);
            var gorev = _gorevService.GetirAciliyetIdIle(model.GorevId);

            var userModel = new AppUserListViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Picture = user.Picture,
                Surname = user.Surname,
                Email = user.Email
            };

            var gorevModel = new GorevListViewModel()
            {
                Id = gorev.Id,
                Aciklama = gorev.Aciklama,
                Aciliyet = gorev.Aciliyet,
                Ad = gorev.Ad
            };

            var personelModel = new PersonelGorevlendirListViewModel()
            {
                AppUser = userModel,
                Gorev = gorevModel
            };

            return View(personelModel);
        }
    }
}
