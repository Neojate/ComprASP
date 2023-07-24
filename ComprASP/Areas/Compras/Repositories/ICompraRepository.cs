using ComprASP.Data;

namespace ComprASP.Areas.Compras.Repositories
{
    public interface ICompraRepository
    {
        public Task<PurchasePrice> GetAsync(int id);

        public Task<IEnumerable<PurchasePrice>> GetAllAsync(int purchaseId);

        public Task<PurchasePrice> Store(PurchasePrice purchasePrice);
    }
}
