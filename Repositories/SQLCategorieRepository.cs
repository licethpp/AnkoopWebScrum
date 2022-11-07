using AankoopData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public class SQLCategorieRepository : ICategorieRepository
    {
        private PrulariaComContext context;
        public SQLCategorieRepository(PrulariaComContext context)
        {
            this.context = context;
        }

        public void AddCategorie(Categorie nieuweCategorie)
        {
            context.Categorieen.Add(nieuweCategorie);
            context.SaveChanges();
        }

        public IEnumerable<Categorie> GetAll()
        {
            return context.Categorieen.Include(a => a.Subcategorieen);
        }

        public IEnumerable<Categorie> GetAllHoofdcategorieen()
        {
            return context.Categorieen.Where(x => x.HoofdCategorie == null);
        }

        public Categorie GetCategorieenByName(string categoriename)
        {
            return context.Categorieen.Where(x => x.Naam.ToLower().Trim() == categoriename.ToLower().Trim()).FirstOrDefault();
        }

        public IEnumerable<Categorie> GetSubcategorieen(int hoofdcategorieid)
        {
            return context.Categorieen.Where(x => x.HoofdCategorieId == hoofdcategorieid);
        }
        public void Update(Categorie changedCategorie)
        {
            //var entry = GetCategorieenByid(changedCategorie.CategorieId);
            //context.Entry(entry).CurrentValues.SetValues(changedCategorie);

            context.Categorieen.Update(changedCategorie);
            context.SaveChanges();
        }

        public Categorie GetById(int categorieId)
        {
            return context.Categorieen
                          .Include(x=>x.HoofdCategorie)
                          .Include(x=>x.Artikelcategorieen)
                          .FirstOrDefault(c => c.CategorieId == categorieId);
        }

        public void Delete(int id)
        {
            Categorie CategorieToRemove = context.Categorieen.Find(id);
            context.Categorieen.Remove(CategorieToRemove);
            context.SaveChanges();
        }
    }
}
