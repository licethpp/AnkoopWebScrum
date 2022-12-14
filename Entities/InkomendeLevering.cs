using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class InkomendeLevering
    {
        public InkomendeLevering()
        {
            Inkomendeleveringslijnen = new HashSet<InkomendeLeveringLijn>();
        }

        public int InkomendeLeveringsId { get; set; }
        public int LeveranciersId { get; set; }
        public string LeveringsbonNummer { get; set; }
        public DateTime Leveringsbondatum { get; set; }
        public DateTime LeverDatum { get; set; }
        public int OntvangerPersoneelslidId { get; set; }

        public virtual Leverancier Leveranciers { get; set; }
        public virtual Personeelslid OntvangerPersoneelslid { get; set; }
        public virtual ICollection<InkomendeLeveringLijn> Inkomendeleveringslijnen { get; set; }
    }
}
