﻿using System.Collections.Generic;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class GorevManager : IGorevService
    {
        private readonly IGorevDal _gorevDal;

        public GorevManager(IGorevDal gorevDal)
        {
            _gorevDal = gorevDal;
        }

        public Gorev GetirAciliyetIdIle(int id)
        {
            return _gorevDal.GetirAciliyetIdIle(id);
        }

        public List<Gorev> GetirAppUserIdIle(int appUserId)
        {
            return _gorevDal.GetirAppUserIdIle(appUserId);
        }

        public List<Gorev> GetirHepsi()
        {
            return _gorevDal.GetirHepsi();
        }

        public Gorev GetirIdile(int id)
        {
            return _gorevDal.GetirIdile(id);
        }

        public List<Gorev> GetirTumTablolarla()
        {
            return _gorevDal.GetirTumTablolarla();
        }

        public void Guncelle(Gorev tablo)
        {
            _gorevDal.Guncelle(tablo);
        }

        public void Kaydet(Gorev tablo)
        {
            _gorevDal.Kaydet(tablo);
        }

        public void Sil(Gorev tablo)
        {
            _gorevDal.Sil(tablo);
        }

        public List<Gorev> TamamlanmayanlariAciliyetIleGetir()
        {
            return _gorevDal.TamamlanmayanlariAciliyetIleGetir();
        }
    }
}
