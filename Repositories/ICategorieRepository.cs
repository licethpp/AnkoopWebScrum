using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetAll();

        public IEnumerable<Categorie> GetAllHoofdcategorieen();

        public IEnumerable<Categorie> GetSubcategorieen(int hoofdcategorieid);

        public void AddCategorie(Categorie nieuweCategorie);

        public Categorie GetCategorieenByName(string categoriename);
     
        void Update(Categorie changedCategorie);
        Categorie GetById(int categorieId);

        void Delete(int id);
    }
}
