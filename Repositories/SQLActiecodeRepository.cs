using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public class SQLActiecodeRepository : IActiecodeRepository
    {
        private PrulariaComContext context;
        public SQLActiecodeRepository(PrulariaComContext context)
        {
            this.context = context;
        }
        public ICollection<Actiecode> GetAll()
        {
            return context.Actiecodes.ToList();
        }
        public Actiecode GetById(int id)
        {
            return context.Actiecodes.FirstOrDefault(x => x.ActiecodeId == id);
        }
        public void Add(Actiecode actiecode)
        {
            context.Actiecodes.Add(actiecode);
            context.SaveChanges();
        }
        public void Update(Actiecode actiecode)
        {
            context.Actiecodes.Update(actiecode);
            context.SaveChanges();
        }
    }
}
