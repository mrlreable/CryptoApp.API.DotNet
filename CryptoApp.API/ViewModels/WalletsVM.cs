namespace CryptoApp.API.ViewModels
{
    public class WalletsVM
    {
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        public virtual DateOnly ExpirationDate { get; set; }
    }
}
