using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Plaats
    {
        public Plaats()
        {
            Adressen = new HashSet<Adres>();
            Leveranciers = new HashSet<Leverancier>();
        }

        public int PlaatsId { get; set; }
        public string Postcode { get; set; }
        public string Naam { get; set; }


        public virtual ICollection<Adres> Adressen { get; set; }
        public virtual ICollection<Leverancier> Leveranciers { get; set; }

        public string DisplayText {
            get {
                return "(" + this.Postcode + ") " + this.Naam;
            }
        }
    }
}
