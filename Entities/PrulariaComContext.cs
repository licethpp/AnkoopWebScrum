using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

#nullable disable

namespace AankoopData.Entities
{
    public partial class PrulariaComContext : DbContext
    {
        //public PrulariaComContext()
        //{
        //}

        public PrulariaComContext(DbContextOptions<PrulariaComContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actiecode> Actiecodes { get; set; }
        public virtual DbSet<Adres> Adressen { get; set; }
        public virtual DbSet<ArtikelCategorie> Artikelcategorieen { get; set; }
        public virtual DbSet<Artikel> Artikelen { get; set; }
        public virtual DbSet<ArtikelLeverancierInfolijn> Artikelleveranciersinfolijnen { get; set; }
        public virtual DbSet<Categorie> Categorieen { get; set; }
        public virtual DbSet<InkomendeLevering> Inkomendeleveringen { get; set; }
        public virtual DbSet<InkomendeLeveringLijn> Inkomendeleveringslijnen { get; set; }
        public virtual DbSet<Leverancier> Leveranciers { get; set; }
        public virtual DbSet<MagazijnPlaats> Magazijnplaatsen { get; set; }
        public virtual DbSet<Personeelslid> Personeelsleden { get; set; }
        public virtual DbSet<PersoneelslidAccount> Personeelslidaccounts { get; set; }
        public virtual DbSet<PersoneelslidSecuritygroep> Personeelslidsecuritygroepen { get; set; }
        public virtual DbSet<Plaats> Plaatsen { get; set; }
        public virtual DbSet<SecurityGroep> Securitygroepen { get; set; }
        public virtual DbSet<VeelGesteldeVragenArtikel> Veelgesteldevragenartikels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actiecode>(entity =>
            {
                entity.HasKey(e => e.ActiecodeId)
                    .HasName("PRIMARY");

                entity.ToTable("actiecodes");

                entity.Property(e => e.ActiecodeId).HasColumnName("actiecodeId");

                entity.Property(e => e.GeldigTotDatum)
                    .HasColumnType("date")
                    .HasColumnName("geldigTotDatum");

                entity.Property(e => e.GeldigVanDatum)
                    .HasColumnType("date")
                    .HasColumnName("geldigVanDatum");

                entity.Property(e => e.IsEenmalig).HasColumnName("isEenmalig");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.AdresId)
                    .HasName("PRIMARY");

                entity.ToTable("adressen");

                entity.HasIndex(e => e.PlaatsId, "fk_Adressen_Plaatsen_idx");

                entity.Property(e => e.AdresId).HasColumnName("adresId");

                entity.Property(e => e.Actief)
                    .IsRequired()
                    .HasColumnName("actief")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Bus)
                    .HasMaxLength(5)
                    .HasColumnName("bus");

                entity.Property(e => e.HuisNummer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("huisNummer");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Straat)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("straat");

                entity.HasOne(d => d.Plaats)
                    .WithMany(p => p.Adressen)
                    .HasForeignKey(d => d.PlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Adressen_Plaatsen");
            });

            modelBuilder.Entity<ArtikelCategorie>(entity =>
            {
                entity.HasKey(e => new { e.CategorieId, e.ArtikelId })
                    .HasName("PRIMARY");

                entity.ToTable("artikelcategorieen");

                entity.HasIndex(e => e.ArtikelId, "fk_ArtikelCategorieen_Artikelen1_idx");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Artikelcategorieen)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelCategorieen_Artikelen1");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Artikelcategorieen)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelCategorieen_Categorieen1");
            });

            modelBuilder.Entity<Artikel>(entity =>
            {
                entity.HasKey(e => e.ArtikelId)
                    .HasName("PRIMARY");

                entity.ToTable("artikelen");

                entity.HasIndex(e => e.Ean, "ean_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.AantalBesteldLeverancier).HasColumnName("aantalBesteldLeverancier");

                entity.Property(e => e.Beschrijving)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("beschrijving");

                entity.Property(e => e.Bestelpeil).HasColumnName("bestelpeil");

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("ean");

                entity.Property(e => e.GewichtInGram).HasColumnName("gewichtInGram");

                entity.Property(e => e.Levertijd)
                    .HasColumnName("levertijd")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxAantalInMagazijnPlaats).HasColumnName("maxAantalInMagazijnPLaats");

                entity.Property(e => e.MaximumVoorraad).HasColumnName("maximumVoorraad");

                entity.Property(e => e.MinimumVoorraad).HasColumnName("minimumVoorraad");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.Property(e => e.Prijs)
                    .HasColumnType("decimal(18,5)")
                    .HasColumnName("prijs");

                entity.Property(e => e.Voorraad).HasColumnName("voorraad");
            });

            modelBuilder.Entity<ArtikelLeverancierInfolijn>(entity =>
            {
                entity.HasKey(e => new { e.ArtikelLeveranciersInfoLijnId, e.ArtikelId })
                    .HasName("PRIMARY");

                entity.ToTable("artikelleveranciersinfolijnen");

                entity.HasIndex(e => e.ArtikelId, "fk_ArtikelLeveranciersInfoLijnen_Artikelen1_idx");

                entity.Property(e => e.ArtikelLeveranciersInfoLijnId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("artikelLeveranciersInfoLijnId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Antwoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("antwoord");

                entity.Property(e => e.Vraag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vraag");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Artikelleveranciersinfolijnen)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelLeveranciersInfoLijnen_Artikelen1");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.CategorieId)
                    .HasName("PRIMARY");

                entity.ToTable("categorieen");

                entity.HasIndex(e => e.HoofdCategorieId, "fk_Categorieen_Categorieen1_idx");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.HoofdCategorieId).HasColumnName("hoofdCategorieId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.HasOne(d => d.HoofdCategorie)
                    .WithMany(p => p.Subcategorieen)
                    .HasForeignKey(d => d.HoofdCategorieId)
                    .HasConstraintName("fk_Categorieen_Categorieen1");
            });

            modelBuilder.Entity<InkomendeLevering>(entity =>
            {
                entity.HasKey(e => e.InkomendeLeveringsId)
                    .HasName("PRIMARY");

                entity.ToTable("inkomendeleveringen");

                entity.HasIndex(e => e.LeveranciersId, "fk_InkomendeLeveringen_Leveranciers1");

                entity.HasIndex(e => e.OntvangerPersoneelslidId, "fk_InkomendeLeveringen_Personeelsleden1_idx");

                entity.Property(e => e.InkomendeLeveringsId).HasColumnName("inkomendeLeveringsId");

                entity.Property(e => e.LeverDatum)
                    .HasColumnType("date")
                    .HasColumnName("leverDatum");

                entity.Property(e => e.LeveranciersId).HasColumnName("leveranciersId");

                entity.Property(e => e.LeveringsbonNummer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("leveringsbonNummer");

                entity.Property(e => e.Leveringsbondatum)
                    .HasColumnType("date")
                    .HasColumnName("leveringsbondatum");

                entity.Property(e => e.OntvangerPersoneelslidId).HasColumnName("ontvangerPersoneelslidId");

                entity.HasOne(d => d.Leveranciers)
                    .WithMany(p => p.Inkomendeleveringen)
                    .HasForeignKey(d => d.LeveranciersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringen_Leveranciers1");

                entity.HasOne(d => d.OntvangerPersoneelslid)
                    .WithMany(p => p.Inkomendeleveringen)
                    .HasForeignKey(d => d.OntvangerPersoneelslidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringen_Personeelsleden1");
            });

            modelBuilder.Entity<InkomendeLeveringLijn>(entity =>
            {
                entity.HasKey(e => new { e.InkomendeLeveringsId, e.ArtikelId, e.MagazijnPlaatsId })
                    .HasName("PRIMARY");

                entity.ToTable("inkomendeleveringslijnen");

                entity.HasIndex(e => e.ArtikelId, "fk_InkomendeLeveringsLijnen_Artikelen1_idx");

                entity.HasIndex(e => e.MagazijnPlaatsId, "fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1_idx");

                entity.Property(e => e.InkomendeLeveringsId).HasColumnName("inkomendeLeveringsId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.MagazijnPlaatsId).HasColumnName("magazijnPlaatsId");

                entity.Property(e => e.AantalGoedgekeurd).HasColumnName("aantalGoedgekeurd");

                entity.Property(e => e.AantalTeruggestuurd).HasColumnName("aantalTeruggestuurd");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Inkomendeleveringslijnen)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_Artikelen1");

                entity.HasOne(d => d.InkomendeLeverings)
                    .WithMany(p => p.Inkomendeleveringslijnen)
                    .HasForeignKey(d => d.InkomendeLeveringsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_InkomendeLeveringen1");

                entity.HasOne(d => d.MagazijnPlaats)
                    .WithMany(p => p.Inkomendeleveringslijnen)
                    .HasForeignKey(d => d.MagazijnPlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1");
            });

            modelBuilder.Entity<Leverancier>(entity =>
            {
                entity.ToTable("leveranciers");

                entity.HasIndex(e => e.PlaatsId, "fk_Leveranciers_Plaatsen1_idx");

                entity.HasKey(e => e.LeveranciersId)
                     .HasName("PRIMARY");

                entity.Property(e => e.BtwNummer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("btwNummer");

                entity.Property(e => e.Bus)
                    .HasMaxLength(5)
                    .HasColumnName("bus");

                entity.Property(e => e.FamilienaamContactpersoon)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaamContactpersoon");

                entity.Property(e => e.HuisNummer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("huisNummer");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Straat)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("straat");

                entity.Property(e => e.VoornaamContactpersoon)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaamContactpersoon");

                entity.HasOne(d => d.Plaats)
                    .WithMany(p => p.Leveranciers)
                    .HasForeignKey(d => d.PlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Leveranciers_Plaatsen1");
            });

            modelBuilder.Entity<MagazijnPlaats>(entity =>
            {
                entity.HasKey(e => e.MagazijnPlaatsId)
                    .HasName("PRIMARY");

                entity.ToTable("magazijnplaatsen");

                entity.HasIndex(e => e.ArtikelId, "fk_MagazijnPlaatsen_Artikelen1_idx");

                entity.HasIndex(e => new { e.Rij, e.Rek }, "uinx_rijrek")
                    .IsUnique();

                entity.Property(e => e.MagazijnPlaatsId).HasColumnName("magazijnPlaatsId");

                entity.Property(e => e.Aantal).HasColumnName("aantal");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Rek).HasColumnName("rek");

                entity.Property(e => e.Rij)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("rij")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Magazijnplaatsen)
                    .HasForeignKey(d => d.ArtikelId)
                    .HasConstraintName("fk_MagazijnPlaatsen_Artikelen1");
            });

            modelBuilder.Entity<Personeelslid>(entity =>
            {
                entity.HasKey(e => e.PersoneelslidId)
                    .HasName("PRIMARY");

                entity.ToTable("personeelsleden");

                entity.HasIndex(e => e.PersoneelslidAccountId, "fk_Personeelsleden_PersoneelslidAccounts1_idx");

                entity.Property(e => e.PersoneelslidId).HasColumnName("personeelslidId");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaam");

                entity.Property(e => e.InDienst)
                    .IsRequired()
                    .HasColumnName("inDienst")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PersoneelslidAccountId).HasColumnName("personeelslidAccountId");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaam");

                entity.HasOne(d => d.PersoneelslidAccount)
                    .WithOne(p => p.Personeelslid)
                    .HasForeignKey<Personeelslid>(d => d.PersoneelslidAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Personeelsleden_PersoneelslidAccounts1");
            });

            modelBuilder.Entity<PersoneelslidAccount>(entity =>
            {
                entity.HasKey(e => e.PersoneelslidAccountId)
                    .HasName("PRIMARY");

                entity.ToTable("personeelslidaccounts");

                entity.HasIndex(e => e.Emailadres, "emailadres_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PersoneelslidAccountId).HasColumnName("personeelslidAccountId");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Emailadres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("emailadres");

                entity.Property(e => e.Paswoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("paswoord");
            });

            modelBuilder.Entity<PersoneelslidSecuritygroep>(entity =>
            {
                entity.HasKey(e => new { e.PersoneelslidId, e.SecurityGroepId })
                    .HasName("PRIMARY");

                entity.ToTable("personeelslidsecuritygroepen");

                entity.HasIndex(e => e.SecurityGroepId, "fk_PersoneelslidSecurityGroepen_SecurityGroepen1_idx");

                entity.Property(e => e.PersoneelslidId).HasColumnName("personeelslidId");

                entity.Property(e => e.SecurityGroepId).HasColumnName("securityGroepId");

                entity.HasOne(d => d.Personeelslid)
                    .WithMany(p => p.Personeelslidsecuritygroepen)
                    .HasForeignKey(d => d.PersoneelslidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PersoneelslidSecurityGroepen_Personeelsleden1");

                entity.HasOne(d => d.SecurityGroep)
                    .WithMany(p => p.Personeelslidsecuritygroepen)
                    .HasForeignKey(d => d.SecurityGroepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PersoneelslidSecurityGroepen_SecurityGroepen1");
            });

            modelBuilder.Entity<Plaats>(entity =>
            {
                entity.HasKey(e => e.PlaatsId)
                    .HasName("PRIMARY");

                entity.ToTable("plaatsen");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("plaats");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("postcode");
            });

            modelBuilder.Entity<SecurityGroep>(entity =>
            {
                entity.HasKey(e => e.SecurityGroepId)
                    .HasName("PRIMARY");

                entity.ToTable("securitygroepen");

                entity.Property(e => e.SecurityGroepId).HasColumnName("securityGroepId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<VeelGesteldeVragenArtikel>(entity =>
            {
                entity.HasKey(e => e.VeelgesteldeVragenArtikelId)
                    .HasName("PRIMARY");

                entity.ToTable("veelgesteldevragenartikels");

                entity.HasIndex(e => e.ArtikelId, "fk_VeelgesteldeVragenArtikels_Artikelen1_idx");

                entity.Property(e => e.VeelgesteldeVragenArtikelId).HasColumnName("veelgesteldeVragenArtikelId");

                entity.Property(e => e.Antwoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("antwoord");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Vraag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vraag");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Veelgesteldevragenartikels)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VeelgesteldeVragenArtikels_Artikelen1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
