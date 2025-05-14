using System;
using System.Collections.Generic;

namespace E_SUN.Models
{
    public partial class Product
    {
        public int No { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public decimal? FeeRate { get; set; }
    }
}
