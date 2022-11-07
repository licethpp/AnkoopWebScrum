using AankoopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AankoopData.Repositories
{
    public class SQLAccountRepository : IAccountRepository
    {
        private PrulariaComContext context;
        public SQLAccountRepository(PrulariaComContext context)
        {
            this.context = context;
        }
    }
}
