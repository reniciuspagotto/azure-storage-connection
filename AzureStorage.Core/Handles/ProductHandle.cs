using AzureStorage.Core.Commands;
using AzureStorage.Core.Contracts;

namespace AzureStorage.Core.Handles
{
    public class ProductHandle : IHandle<ProductCreateCommand>
    {
        public object Handle(ProductCreateCommand command)
        {
            return command;
        }
    }
}
