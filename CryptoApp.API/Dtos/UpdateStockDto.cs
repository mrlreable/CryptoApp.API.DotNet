namespace CryptoApp.API.Dtos
{
    public class UpdateStockDto
    {
        public int Id { get; set; }
        public double? Price { get; set; }
        public double? Spread { get; set; }
        public bool? IsSupported { get; set; }
        public double? Change { get; set; }
        public string? Description { get; set; }
    }
}
