using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprASP.Data
{
    public class PurchasePrice
    {
        public int Id {  get; set; }

        public int PurchaseId { get; set; }

        public int MarketId { get; set; }

        public int Price { get; set; }

        public DateTime PayedAt { get; set; }

        public Purchase Purchase { get; set; }

        public Market Market { get; set; } 
    }
}
