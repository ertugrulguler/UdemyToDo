using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IGorevService : IGenericService<Gorev>
    {
        List<Gorev> TamamlanmayanlariAciliyetIleGetir();
        List<Gorev> GetirTumTablolarla();
        Gorev GetirAciliyetIdIle(int id);
        List<Gorev> GetirAppUserIdIle(int appUserId);
    }
}
