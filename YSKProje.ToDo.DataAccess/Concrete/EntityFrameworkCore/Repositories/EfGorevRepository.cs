﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGorevRepository : EfGenericRepository<Gorev>, IGorevDal
    {
        public Gorev GetirAciliyetIdIle(int id)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(i => i.Aciliyet).FirstOrDefault(i => i.Durum == false && i.Id == id);
        }

        public List<Gorev> GetirAppUserIdIle(int appUserId)
        {
            using var context = new TodoContext();
            return context.Gorevler.Where(i => i.AppUserId == appUserId).ToList(); 
        }

        public List<Gorev> GetirTumTablolarla()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(i => i.Aciliyet).Include(i => i.Raporlar).Include(i => i.AppUser).Where(i => i.Durum == false).OrderByDescending(i => i.OlusturulmaTarih).ToList();
        }

        public List<Gorev> TamamlanmayanlariAciliyetIleGetir()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(i => i.Aciliyet).Where(i => i.Durum == false).OrderBy(i => i.OlusturulmaTarih).ToList();
        }
    }
}
