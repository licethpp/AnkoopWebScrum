using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class SecurityGroep
    {
        public SecurityGroep()
        {
            Personeelslidsecuritygroepen = new HashSet<PersoneelslidSecuritygroep>();
        }

        public int SecurityGroepId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<PersoneelslidSecuritygroep> Personeelslidsecuritygroepen { get; set; }
    }
}
