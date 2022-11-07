using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AankoopData.Entities
{
    public partial class Artikel
    {
        public Artikel()
        {
            Artikelcategorieen = new HashSet<ArtikelCategorie>();
            Artikelleveranciersinfolijnen = new HashSet<ArtikelLeverancierInfolijn>();
            Inkomendeleveringslijnen = new HashSet<InkomendeLeveringLijn>();
            Magazijnplaatsen = new HashSet<MagazijnPlaats>();
            Veelgesteldevragenartikels = new HashSet<VeelGesteldeVragenArtikel>();
        }

        public int ArtikelId { get; set; }
        public string Ean { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public decimal Prijs { get; set; }
        public int GewichtInGram { get; set; }
        public int Bestelpeil { get; set; }
        public int Voorraad { get; set; }
        public int MinimumVoorraad { get; set; }
        public int MaximumVoorraad { get; set; }
        public int Levertijd { get; set; }
        public int AantalBesteldLeverancier { get; set; }
        public int MaxAantalInMagazijnPlaats { get; set; }

        public virtual ICollection<ArtikelCategorie> Artikelcategorieen { get; set; }
        public virtual ICollection<ArtikelLeverancierInfolijn> Artikelleveranciersinfolijnen { get; set; }
        public virtual ICollection<InkomendeLeveringLijn> Inkomendeleveringslijnen { get; set; }
        public virtual ICollection<MagazijnPlaats> Magazijnplaatsen { get; set; }
        public virtual ICollection<VeelGesteldeVragenArtikel> Veelgesteldevragenartikels { get; set; }

        public bool Actief
        {
            get
            {
                return !(this.MinimumVoorraad == 0
                    && this.MaximumVoorraad == 0
                    && this.Bestelpeil == 0
                    && this.AantalBesteldLeverancier == 0);
            }
        }

        [Display(Name = "Verschil")]
        public int Verschil {
            get {
                return this.Voorraad - this.Bestelpeil;
            }
        }

        public bool Rood {
            get {
                return this.Voorraad < this.MinimumVoorraad;
            }
        }

        public bool Oranje {
            get {
                return this.Voorraad < this.Bestelpeil;
            }
        }
    }
}
