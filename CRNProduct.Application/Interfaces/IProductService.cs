using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<IEnumerable<Product>> GetPagedAsync(int pageNumber, int pageSize);

        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id);
    }
}