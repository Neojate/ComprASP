using System.Text.Json.Serialization;

namespace ComprASP.Data
{
    public class Purchase
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public User? User { get; set; }

        public IEnumerable<ProductPurchase>? ProductPurchases { get; set; }

        public IEnumerable<PurchasePrice>? PurchasePrices { get; set; }
    }
}
