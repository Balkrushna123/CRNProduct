using CRNProduct.Application.Interfaces;
using CRNProduct.Domain.Entities;
using CRNProduct.Infrastructure.Data;
using CRNProduct.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRNProduct.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}