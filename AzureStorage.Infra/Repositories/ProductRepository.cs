using AzureStorage.Core.Contracts;
using AzureStorage.Core.Entities;
using AzureStorage.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorage.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dataContext.Products.ToList();
        }

        public void Save(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }
    }
}
