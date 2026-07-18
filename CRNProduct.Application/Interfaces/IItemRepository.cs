using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsByProductIdAsync(int productId);
    }
}