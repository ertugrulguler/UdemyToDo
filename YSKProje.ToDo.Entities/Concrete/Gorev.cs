﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Gorev : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }

        public int? AppUserId { get; set; } //görec önce oluşturulup sonra birine atama yapılabilir
        public AppUser AppUser { get; set; }


        public List<Rapor> Raporlar { get; set; }
    }
}
