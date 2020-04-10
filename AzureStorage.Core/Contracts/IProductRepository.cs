using AzureStorage.Core.Entities;
using System.Collections.Generic;

namespace AzureStorage.Core.Contracts
{
    public interface IProductRepository
    {
        void Save(Product product);
        IEnumerable<Product> GetAll();
    }
}
