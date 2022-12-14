namespace CryptoApp.API.Dtos
{
    public class CreateNewsDto : IEntityDto
    {
        public virtual string Label { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
    }
}
