using AzureStorage.Infra.Contract;
using Microsoft.AspNetCore.Http;

namespace AzureStorage.Infra.Repository
{
    public class FileRepository : IFileRepository
    {
        public string Upload(IFormFile file)
        {
            return string.Empty;
        }
    }
}
