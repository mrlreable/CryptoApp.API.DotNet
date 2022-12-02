using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class UserCrypto
    {
        [Required]
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public virtual int CryptoId { get; set; }
        public virtual CryptoCurrency Crypto { get; set; }
        public virtual double Balance { get; set; }
        public virtual DateTime LatestPurchase { get; set; }
    }
}
