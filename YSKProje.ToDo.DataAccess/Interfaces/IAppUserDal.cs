using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Interfaces
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        List<AppUser> GetirAdminOlmayanlar();
        List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, string q, int aktifSayfa = 1);
    }
}
