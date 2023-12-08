using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakazObedov1.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        //public int MealID { get; set; }
        public int? RestaurantID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderStatus { get; set; }

        public User? User { get; set; }
        //public Meal Meal{ get; set; }

        public Restaurant? Restaurant { get; set; }
    }
}
