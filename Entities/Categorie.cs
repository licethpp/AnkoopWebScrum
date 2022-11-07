using System;
using System.Collections.Generic;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Categorie
    {
        public Categorie()
        {
            Artikelcategorieen = new HashSet<ArtikelCategorie>();
            Subcategorieen = new HashSet<Categorie>();
        }

        public int CategorieId { get; set; }
        public string Naam { get; set; }
        public int? HoofdCategorieId { get; set; }

        public virtual Categorie HoofdCategorie { get; set; }
        public virtual ICollection<ArtikelCategorie> Artikelcategorieen { get; set; }
        public virtual ICollection<Categorie> Subcategorieen { get; set; }
    }
}
