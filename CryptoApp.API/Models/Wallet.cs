namespace CryptoApp.API.Models
{
    public class Wallet
    {
        public virtual int Id { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual User User { get; set; }
        public virtual string UserId { get; set; }
    }
}
