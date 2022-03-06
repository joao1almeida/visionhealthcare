using DB;
using DB.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseDbContext _context;
        public ProductRepository(DatabaseDbContext ctx)
        {
            _context = ctx;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await _context.Product.Where(p => p.Name.Contains(name)).ToListAsync();
        }
        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await _context.Product.FindAsync(productId);
        }
        public async Task InsertAsync(Product product)
        {
            await _context.Product.AddAsync(product);
        }
        public async Task BulkInsertAsync(IEnumerable<Product> products)
        {
            await _context.Product.AddRangeAsync(products);
        }
        public async Task UpdateAsync(Product product)
        {
             var toUpdate = await _context.Product.FindAsync(product.ProductId);
            _context.Entry(toUpdate).CurrentValues.SetValues(product);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Guid productId)
        {
            Product employee = await _context.Product.FindAsync(productId);
            _context.Product.Remove(employee);
            await Task.CompletedTask;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
