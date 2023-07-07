using ComprASP.ViewModels.ProductPurchases;

namespace ComprASP.ViewModels.Purchases
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public string? Name { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public IEnumerable<ProductPurchaseViewModel> ProductPurchases { get; set; } = new List<ProductPurchaseViewModel>();

    }
}
