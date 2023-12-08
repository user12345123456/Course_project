using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakzObedov1.ZakazDto
{
    public class CreateRestaurantDto
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public int? MenuID { get; set; }
    }
}
