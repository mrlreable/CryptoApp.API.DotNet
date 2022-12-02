namespace CryptoApp.API.Dtos
{
    public class UpdateNewsDto : IEntityDto
    {
        public string? UpdatedLabel { get; set; }
        public string? UpdatedTitle { get; set; }
        public string? UpdatedContent { get; set; }
    }
}
