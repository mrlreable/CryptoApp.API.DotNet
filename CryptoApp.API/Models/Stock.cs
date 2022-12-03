using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public class Stock : AssetBase
    {
        [Required]
        public virtual double Price { get; set; }
        [Required]
        public virtual double Spread { get; set; }
        public virtual ICollection<UserStock> UserStocks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
