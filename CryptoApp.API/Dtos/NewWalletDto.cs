using AutoMapper.Configuration.Annotations;
using CryptoApp.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryptoApp.API.Dtos
{
    public class NewWalletDto : IEntityDto
    {
        public string CardNumber { get; set; }
        public string Cardholder { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public double Balance { get; set; }
        [Ignore]
        public string Currency { get; set; }
    }
}
