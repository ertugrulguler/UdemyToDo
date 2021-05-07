using System.Collections.Generic;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Interfaces
{
    public interface IGorevDal : IGenericDal<Gorev>
    {
        List<Gorev> TamamlanmayanlariAciliyetIleGetir();
        List<Gorev> GetirTumTablolarla();
        Gorev GetirAciliyetIdIle(int id);
        List<Gorev> GetirAppUserIdIle(int appUserId);
    }
}
