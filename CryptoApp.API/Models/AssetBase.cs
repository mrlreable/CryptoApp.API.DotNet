using System.ComponentModel.DataAnnotations;

namespace CryptoApp.API.Models
{
    public abstract class AssetBase
    {
        [Required]
        public virtual int Id { get; set; }
        [Required, MaxLength(50)]
        public virtual string Name { get; set; }
        [Required, MaxLength(5)]
        public virtual string ShortName { get; set; }
        [Required]
        public virtual bool IsSupported { get; set; }
        [Required]
        public virtual double Change { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual string? UpdatedById { get; set; }
        public virtual User? UpdatedBy { get; set; }
        [MaxLength(500)]
        public virtual string? Description { get; set; }
    }
}
