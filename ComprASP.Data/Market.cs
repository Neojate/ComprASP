namespace ComprASP.Data
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public User User { get; set; } 
    }
}
