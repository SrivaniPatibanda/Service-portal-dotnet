﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CommonData.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerAmount { get; set; }
    }
}
