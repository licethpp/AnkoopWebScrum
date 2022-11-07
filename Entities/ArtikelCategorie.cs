using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class ArtikelCategorie
    {
        public int CategorieId { get; set; }
        public int ArtikelId { get; set; }

        public virtual Artikel Artikel { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
