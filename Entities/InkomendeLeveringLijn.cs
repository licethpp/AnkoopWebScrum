using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class InkomendeLeveringLijn
    {
        public int InkomendeLeveringsId { get; set; }
        public int ArtikelId { get; set; }
        public int AantalGoedgekeurd { get; set; }
        public int AantalTeruggestuurd { get; set; }
        public int MagazijnPlaatsId { get; set; }

        public virtual Artikel Artikel { get; set; }
        public virtual InkomendeLevering InkomendeLeverings { get; set; }
        public virtual MagazijnPlaats MagazijnPlaats { get; set; }
    }
}
