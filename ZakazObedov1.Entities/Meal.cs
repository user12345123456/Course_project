using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakazObedov1.Entities
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public string Description { get; set; }
        //public List<Order> Orders { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
