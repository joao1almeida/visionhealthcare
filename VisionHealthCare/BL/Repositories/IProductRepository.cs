using DB.DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        Task<Product> GetByIdAsync(Guid productId);
        Task InsertAsync (Product products);
        Task BulkInsertAsync(IEnumerable<Product> products);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid productId);
        Task<int> SaveAsync();
    }
}
