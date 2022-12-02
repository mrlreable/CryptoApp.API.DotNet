using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class UserStock
    {
        [Required]
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int StockId { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual double Balance { get; set; }
        public virtual DateTime LatestPurchase { get; set; }
    }
}
