using AzureStorage.Core.Commands;
using AzureStorage.Core.Contracts;
using AzureStorage.Core.Entities;

namespace AzureStorage.Core.Handles
{
    public class ProductHandle : IHandle<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public object Handle(CreateProductCommand command)
        {
            _productRepository.Save(new Product(command.Name, command.Price, command.ImageUrl));
            return command;
        }
    }
}
