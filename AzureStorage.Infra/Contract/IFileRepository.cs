using Microsoft.AspNetCore.Http;

namespace AzureStorage.Infra.Contract
{
    public interface IFileRepository
    {
        string Upload(IFormFile file);
    }
}
