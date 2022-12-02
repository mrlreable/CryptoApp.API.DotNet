namespace CryptoApp.API.Models
{
    public class Wallet
    {
        public virtual int Id { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        // This is only to provide functionality to the service that is checking if you can buy
        public virtual float Balance { get; set; }
        public virtual int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
        public virtual string UserId { get; set; }
    }
}
