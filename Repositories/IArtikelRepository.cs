using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public interface IArtikelRepository
    {
        public ICollection<Artikel> FindAll();
        public void Add(Artikel article);
        IEnumerable<Artikel> GetArticlesByEan(string ean);
        public Artikel FindByName(string naam);
        ICollection<Artikel> FindArtikelenByCategorie(int categorieid);
        void Update(Artikel artikel);
        Artikel GetById(int id);
        void RemoveCategoryFromArticle(ArtikelCategorie artikelCategorie);
        void AddCategoryToArticle(ArtikelCategorie artikelCategorie);
    }
}
