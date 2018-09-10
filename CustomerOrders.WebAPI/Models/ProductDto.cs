﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.WebAPI.Models
{
    public class ProductDto
    {
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
    }
}