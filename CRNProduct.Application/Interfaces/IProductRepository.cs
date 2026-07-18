using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductWithItemsAsync(int id);
    }
}