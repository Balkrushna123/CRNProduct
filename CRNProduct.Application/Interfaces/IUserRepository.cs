using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUserNameAsync(string userName);
    }
}