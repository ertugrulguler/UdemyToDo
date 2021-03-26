using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetirAdminOlmayanlar()
        {
            return _userDal.GetirAdminOlmayanlar();
        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa,string q, int aktifSayfa)
        {
            return _userDal.GetirAdminOlmayanlar(out toplamSayfa,  q, aktifSayfa);
        }
    }
}
