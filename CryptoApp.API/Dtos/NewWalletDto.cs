namespace CryptoApp.API.Dtos
{
    public class NewWalletDto
    {
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        public virtual DateOnly ExpirationDate { get; set; }
    }
}
