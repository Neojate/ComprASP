using ComprASP.ViewModels.Markets;

namespace ComprASP.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }

        public MarketViewModel Market { get; set; }
    }
}
