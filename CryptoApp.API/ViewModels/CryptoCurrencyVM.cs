
namespace CryptoApp.API.ViewModels
{
    public class CryptoCurrencyVM : IEntityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public string? Description { get; set; }
        public double? MarketCap { get; set; }
    }
}
