using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class UserCurrency
    {
        [Required]
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public virtual int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual double Balance { get; set; }
        public virtual DateTime LatestPurchase { get; set; }
    }
}
