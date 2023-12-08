using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakzObedov1.ZakazDto
{
    public class CreateMealDto
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public int? RestaurantID { get; set; }
    }
}
