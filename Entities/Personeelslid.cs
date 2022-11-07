using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Personeelslid
    {
        public Personeelslid()
        {
            Inkomendeleveringen = new HashSet<InkomendeLevering>();
            Personeelslidsecuritygroepen = new HashSet<PersoneelslidSecuritygroep>();
        }

        public int PersoneelslidId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public bool? InDienst { get; set; }
        public int PersoneelslidAccountId { get; set; }

        public virtual PersoneelslidAccount PersoneelslidAccount { get; set; }
        public virtual ICollection<InkomendeLevering> Inkomendeleveringen { get; set; }
        public virtual ICollection<PersoneelslidSecuritygroep> Personeelslidsecuritygroepen { get; set; }
    }
}
