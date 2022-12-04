using AutoMapper.Configuration.Annotations;

namespace CryptoApp.API.ViewModels
{
    public class WalletsVM : IAssetVM
    {
        public virtual int Id { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual double Balance { get; set; }
        [Ignore]
        public virtual string? Currency { get; set; }
    }
}
