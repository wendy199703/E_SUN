using Microsoft.EntityFrameworkCore;

namespace E_SUN.Models.ViewModel
{
    public class LikeListModel
    {
        public int? SN { get; set; }
        public string? UserId {  get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserAccount { get; set; }
        public int OrderPrice { get; set; }
        public int OrderFee { get; set; }
        public string? OrderAccount { get; set; }
        public int OrderCount { get; set; }
        public DateTime? OrderCreateDate { get; set; }
        public DateTime? OrderUpdateDate { get; set; }
    }
}
