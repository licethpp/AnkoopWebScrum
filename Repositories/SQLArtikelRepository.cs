using AankoopData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AankoopData.Repositories
{
    public class SQLArtikelRepository : IArtikelRepository
    {
        //private readonly ILogger logger;
        private readonly PrulariaComContext context;

        public SQLArtikelRepository(PrulariaComContext context)
        {
            //this.logger = logger;
            this.context = context;
        }

        public IEnumerable<Artikel> GetArticlesByEan(string ean)
        {
            return (from a in context.Artikelen
                    where a.Ean.Contains(ean)
                    orderby a.Naam
                    select a);
        }
        public ICollection<Artikel> FindAll()
        {
            return context.Artikelen.ToList();
        }

        public ICollection<Artikel> FindArtikelenByCategorie(int categorieid)
        {
            return context.Artikelcategorieen.Where(x => x.CategorieId == categorieid).Select(x => x.Artikel).ToList();
        }

        //Nieuw gemaakt artikel toevoegen in DB
        public void Add(Artikel article)
        {
                context.Artikelen.Add(article);
                context.SaveChanges();
        }

        public Artikel FindByName(string naam)
        {
            return context.Artikelen.Where(x => x.Naam == naam).FirstOrDefault();
        }

        public void Update(Artikel artikel)
        {
            try
            {
                context.Artikelen.Update(artikel);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // logger.LogError(ex.Message);
            }
        }

        public Artikel GetById(int id)
        {
            return (from a in context.Artikelen
                    .Include(a => a.Artikelcategorieen)
                    .ThenInclude(a => a.Categorie)
                    where a.ArtikelId == id
                    select a).AsNoTracking().FirstOrDefault();
        }

        public void RemoveCategoryFromArticle(ArtikelCategorie artikelCategorie) {
            context.Artikelcategorieen.Remove(artikelCategorie);
            context.SaveChanges();
        }

        public void AddCategoryToArticle(ArtikelCategorie artikelCategorie) {
            context.Artikelcategorieen.Add(artikelCategorie);
            context.SaveChanges();
        }
    }
}

