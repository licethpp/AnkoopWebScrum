using AankoopData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Threading.Tasks;
using AankoopData.Entities;


namespace AankoopData.Repositories
{
    public class SQLLeverancierRepository : ILeverancierRepository
    {
        private PrulariaComContext context;

        public SQLLeverancierRepository(PrulariaComContext context)
        {
            this.context = context;
        }
        public void Edit(Leverancier lev)
        {
            context.Update(lev);
            context.SaveChanges();
        }
        public Leverancier GetById(int? id)
        {
            return (from a in context.Leveranciers
                    where a.LeveranciersId == id
                    select a).FirstOrDefault();
        }
        public Plaats GetPlaatsByName(string naam)
        {
            return (from a in context.Plaatsen
                    where a.Naam == naam
                    select a).FirstOrDefault();
        }
        public Plaats GetPlaatsById(int? id)
        {
            return (from a in context.Plaatsen
                    where a.PlaatsId == id
                    select a).FirstOrDefault();
        }
        public IEnumerable<Leverancier> GetAllLeverancier()
        {

            return context.Leveranciers
                .Include(l => l.Plaats)
                .ToList();

        }

        public void Create(Leverancier leverancier) 
        {
            context.Leveranciers.Add(leverancier);
            context.SaveChanges();
        }

        public SelectList selectListPlaatsen(Leverancier leverancier = null) 
        {
            if (leverancier != null) 
            {
                return new SelectList(context.Plaatsen, "PlaatsId", "DisplayText", leverancier.PlaatsId);
            }

            return new SelectList(context.Plaatsen, "PlaatsId", "DisplayText");
        }


        public IEnumerable<Plaats> GetAllPlaatsen()
        {
            return context.Plaatsen.ToList();
        }
    }
}
