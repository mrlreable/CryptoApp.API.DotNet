using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class Wallet
    {
        public virtual int Id { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime ExpirationDate { get; set; }
        // This is only to provide functionality to the service that is checking if you can buy
        public virtual double Balance { get; set; }
        [Ignore]
        public virtual int CurrencyId { get; set; }
        [Ignore]
        public virtual Currency Currency { get; set; }
        [Ignore]
        public virtual User User { get; set; }
        [Ignore]
        public virtual string UserId { get; set; }
    }
}
