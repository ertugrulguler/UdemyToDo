using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.Todo.Web.Areas.Admin.Models
{
    public class PersonelGorevlendirListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public GorevListViewModel Gorev { get; set; }
    }
}
