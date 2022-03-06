using DB.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext()
        {

        }
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
