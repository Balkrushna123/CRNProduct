using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Products.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.CreatedOn = DateTime.UtcNow;

            await _unitOfWork.Products.AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            product.ModifiedOn = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found.");

            _unitOfWork.Products.Delete(product);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}