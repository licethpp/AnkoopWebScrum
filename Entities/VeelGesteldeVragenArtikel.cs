using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class VeelGesteldeVragenArtikel
    {
        public int VeelgesteldeVragenArtikelId { get; set; }
        public int ArtikelId { get; set; }
        public string Vraag { get; set; }
        public string Antwoord { get; set; }

        public virtual Artikel Artikel { get; set; }
    }
}
