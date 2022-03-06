using BL.Repositories;
using DB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IProductService 
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(Guid productId);
        Task<IEnumerable<Product>> SearchByName(string name);
        Task Add(Product products);
        Task Add(IEnumerable<Product> products);
        Task Update(Product product);
        Task Delete(Guid productId);
    }
}
