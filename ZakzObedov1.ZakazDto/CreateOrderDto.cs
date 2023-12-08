using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakzObedov1.ZakazDto
{
    public class CreateOrderDto
    {
        public int? UserID { get; set; }
        public int? RestaurantID { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? OrderStatus { get; set; }

    }
}
