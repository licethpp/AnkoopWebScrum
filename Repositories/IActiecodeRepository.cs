using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public interface IActiecodeRepository
    {
        ICollection<Actiecode> GetAll();
        Actiecode GetById(int id);
        void Add(Actiecode actiecode);
        void Update(Actiecode actiecode);
    }
}
