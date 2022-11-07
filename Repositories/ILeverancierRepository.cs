using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AankoopData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AankoopData.Repositories
{
    public interface ILeverancierRepository
    {
        void Edit(Leverancier lev);
        Leverancier GetById(int? id);
        Plaats GetPlaatsByName(string naam);
        Plaats GetPlaatsById(int? id);
        public IEnumerable<Leverancier> GetAllLeverancier();
        void Create(Leverancier leverancier);
        SelectList selectListPlaatsen(Leverancier leverancier = null);

        public IEnumerable<Plaats> GetAllPlaatsen();

    }
}
