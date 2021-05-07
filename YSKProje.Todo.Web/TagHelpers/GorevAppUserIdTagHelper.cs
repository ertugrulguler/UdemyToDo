using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using YSKProje.ToDo.Business.Interfaces;

namespace YSKProje.Todo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper : TagHelper
    {
        private readonly IGorevService _gorevService;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }

        public int AppUserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var gorevler = _gorevService.GetirAppUserIdIle(AppUserId);
            int tamamlananGorevSayisi = gorevler.Where(i => i.Durum).Count();
            int tamamlanmayanGorevSayisi = gorevler.Where(i => !i.Durum).Count();


            string htmlString = $"<strong>Tamamladığı görev sayısı : {tamamlananGorevSayisi}</strong> <br>  <strong>Üzerinde çalıştığı görev sayısı : {tamamlanmayanGorevSayisi}</strong>";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
