using Microsoft.AspNetCore.Identity;

namespace CryptoApp.API.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Wallet>? Wallets { get; set; }
        public virtual ICollection<UserCrypto> UserCryptos { get; set; }
        public virtual ICollection<UserCurrency> UserCurrencies { get; set; }
        public virtual ICollection<UserStock> UserStocks { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<News> NewsCreated { get; set; }
        public virtual ICollection<CryptoCurrency> UpdatedCryptos { get; set; }
        public virtual ICollection<Currency> UpdatedCurrencies { get; set; }
        public virtual ICollection<Stock> UpdatedStocks { get; set; }
    }
}
