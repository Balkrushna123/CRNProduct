using CRNProduct.Application.Interfaces;

namespace CRNProduct.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IProductRepository Products { get; }

        public IItemRepository Items { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IProductRepository productRepository,
            IItemRepository itemRepository,
            IUserRepository userRepository)
        {
            _context = context;
            Products = productRepository;
            Items = itemRepository;
            Users = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}