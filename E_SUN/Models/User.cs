using System;
using System.Collections.Generic;

namespace E_SUN.Models
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Account { get; set; }
    }
}
