using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _unitOfWork.Items.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Items.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Item>> GetByProductIdAsync(int productId)
        {
            return await _unitOfWork.Items.GetItemsByProductIdAsync(productId);
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await _unitOfWork.Items.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Item item)
        {
            _unitOfWork.Items.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(id);

            if (item == null)
                throw new Exception("Item not found.");

            _unitOfWork.Items.Delete(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}