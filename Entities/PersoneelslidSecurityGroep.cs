using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class PersoneelslidSecuritygroep
    {
        public int PersoneelslidId { get; set; }
        public int SecurityGroepId { get; set; }

        public virtual Personeelslid Personeelslid { get; set; }
        public virtual SecurityGroep SecurityGroep { get; set; }
    }
}
