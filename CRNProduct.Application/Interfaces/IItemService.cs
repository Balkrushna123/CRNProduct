using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(int id);

        Task<IEnumerable<Item>> GetByProductIdAsync(int productId);

        Task<Item> CreateAsync(Item item);

        Task UpdateAsync(Item item);

        Task DeleteAsync(int id);
    }
}