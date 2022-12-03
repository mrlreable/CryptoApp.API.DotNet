
namespace CryptoApp.API.ViewModels
{
    public class CurrencyVM : IAssetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual double Change { get; set; }
        public virtual double ExchangeRateHUF { get; set; }
        public virtual double ExchangeRateEUR { get; set; }
        public virtual double ExchangeRateUSD { get; set; }
        public virtual string? MinorUnit { get; set; }
        public virtual string? CentralBank { get; set; }
        public string? Description { get; set; }
    }
}
