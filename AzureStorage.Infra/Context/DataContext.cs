using AzureStorage.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureStorage.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
