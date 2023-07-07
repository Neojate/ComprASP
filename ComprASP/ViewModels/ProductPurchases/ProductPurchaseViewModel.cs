using ComprASP.ViewModels.Products;
using ComprASP.ViewModels.Purchases;

namespace ComprASP.ViewModels.ProductPurchases
{
    public class ProductPurchaseViewModel
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public PurchaseViewModel Purchase { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
