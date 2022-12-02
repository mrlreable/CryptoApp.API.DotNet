using AutoMapper.Configuration.Annotations;
using CryptoApp.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryptoApp.API.Dtos
{
    public class NewWalletDto : IEntityDto
    {
        public virtual string CardNumber { get; set; }
        public virtual string Cardholder { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime ExpirationDate { get; set; }
        public virtual float Balance { get; set; }
        [Ignore]
        public virtual string Currency { get; set; }
    }
}
