using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class PersoneelslidAccount
    {

        public int PersoneelslidAccountId { get; set; }
        public string Emailadres { get; set; }
        public string Paswoord { get; set; }
        public bool Disabled { get; set; }

        public virtual Personeelslid Personeelslid { get; set; }

    }
}
