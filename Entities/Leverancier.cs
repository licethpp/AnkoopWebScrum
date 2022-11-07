using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Leverancier
    {
        public Leverancier()
        {
            Inkomendeleveringen = new HashSet<InkomendeLevering>();
        }

        public int LeveranciersId { get; set; }
        public string Naam { get; set; }
        public string BtwNummer { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Bus { get; set; }
        public int PlaatsId { get; set; }
        public string FamilienaamContactpersoon { get; set; }
        public string VoornaamContactpersoon { get; set; }

        public virtual Plaats Plaats { get; set; }
        public virtual ICollection<InkomendeLevering> Inkomendeleveringen { get; set; }
    }
}
