using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakazObedov1.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? MenuID { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Meal>? Meals { get; set; }
    }
}
