using System;
using System.Collections.Generic;

namespace E_SUN.Models
{
    public partial class LikeList
    {
        public int Sn { get; set; }
        public int? OrderName { get; set; }
        public string? Account { get; set; }
        public int? TotalFee { get; set; }
        public int? TotalAmount { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdaeDate { get; set; }
    }
}
