﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakzObedov1.ZakazDto
{
    public class CreateUserDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
