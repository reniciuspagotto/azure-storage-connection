using AzureStorage.Core.Commands;
using AzureStorage.Core.Contracts;
using AzureStorage.Core.Entities;

namespace AzureStorage.Core.Handles
{
    public class ProductHandle : IHandle<ProductCreateCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public object Handle(ProductCreateCommand command)
        {
            _productRepository.Save(new Product(command.Name, command.Price, command.ImageUrl));
            return command;
        }
    }
}
