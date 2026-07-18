using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRNProduct.Infrastructure.Data.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetItemsByProductIdAsync(int productId)
        {
            return await _context.Items
                .Where(i => i.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}