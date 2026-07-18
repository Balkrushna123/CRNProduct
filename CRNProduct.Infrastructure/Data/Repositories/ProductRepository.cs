using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRNProduct.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetProductWithItemsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}