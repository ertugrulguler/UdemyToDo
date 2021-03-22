using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace YSKProje.Todo.Web.Areas.Admin.Models
{
    public class GorevAddViewModel
    {
        [Required(ErrorMessage ="Ad alanı boş geçilemez.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen aciliyet durumu seçiniz.")]
        public int AciliyetId { get; set; }

    }
}
