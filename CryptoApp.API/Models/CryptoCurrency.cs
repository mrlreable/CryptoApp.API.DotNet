using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class CryptoCurrency : AssetBase
    {
        [Required]
        public virtual double Price { get; set; }
        public virtual double? MarketCap { get; set; }
        public virtual ICollection<UserCrypto> UserCryptos { get; set; }
    }
}
