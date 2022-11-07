using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class MagazijnPlaats
    {
        public MagazijnPlaats()
        {
            Inkomendeleveringslijnen = new HashSet<InkomendeLeveringLijn>();
        }

        public int MagazijnPlaatsId { get; set; }
        public int? ArtikelId { get; set; }
        public string Rij { get; set; }
        public int Rek { get; set; }
        public int Aantal { get; set; }

        public virtual Artikel Artikel { get; set; }
        public virtual ICollection<InkomendeLeveringLijn> Inkomendeleveringslijnen { get; set; }
    }
}
