namespace CryptoApp.API.Dtos
{
    public class NewStockDto
    {
        public double Price { get; set; }
        public double Spread { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsSupported { get; set; }
        public double Change { get; set; }
        public string Description { get; set; }
    }
}
