namespace CryptoApp.API.ViewModels
{
    public class NewsVM : IEntityVM
    {
        public virtual int Id { get; set; }
        public virtual string Label { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual string Content { get; set; }
    }
}
