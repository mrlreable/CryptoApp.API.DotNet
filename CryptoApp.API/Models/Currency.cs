using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class Currency : AssetBase
    {
        [Required]
        public virtual double ExchangeRateHUF { get; set; }
        [Required]
        public virtual double ExchangeRateEUR { get; set; }
        [Required]
        public virtual double ExchangeRateUSD { get; set; }
        public virtual string? MinorUnit { get; set; }
        public virtual string? CentralBank { get; set; }
        public virtual ICollection<UserCurrency> UserCurrencies { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
