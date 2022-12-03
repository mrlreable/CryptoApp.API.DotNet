namespace CryptoApp.API.ViewModels
{
    public class StockVM : IAssetVM
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }
        public virtual double Price { get; set; }
        public virtual double Spread { get; set; }
        public virtual double Change { get; set; }
        public virtual string? Description { get; set; }
    }
}
