using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakazObedov1.DataAccess.Repository
{
   public class BaseRepository
    {
        public readonly ZakazObedov1DBContext _zakazobedov1Context;

        public BaseRepository(ZakazObedov1DBContext valuationContext)
        {
            _zakazobedov1Context = valuationContext;
        }
    }
}
