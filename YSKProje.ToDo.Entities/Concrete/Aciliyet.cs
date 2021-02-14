using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Aciliyet
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Gorev> Gorevler { get; set; }
    }
}
