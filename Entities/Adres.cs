using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Adres
    {
        public int AdresId { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Bus { get; set; }
        public int PlaatsId { get; set; }
        public bool? Actief { get; set; }

        public virtual Plaats Plaats { get; set; }
    }
}
