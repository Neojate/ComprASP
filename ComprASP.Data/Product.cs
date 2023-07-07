namespace ComprASP.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; } 
        public string UserId { get; set; }

        public Market Market { get; set; }
        public User User { get; set; }
    }
}
