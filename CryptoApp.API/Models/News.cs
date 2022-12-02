namespace CryptoApp.API.Models
{
    public class News
    {
        public virtual int Id { get; set; }
        public virtual string Label { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? ModifiedAt { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual string CreatedById { get; set; }
        public virtual User? ModifiedBy { get; set; }
        public virtual string? ModifiedById { get; set; }
        public virtual string Content { get; set; }
    }
}
