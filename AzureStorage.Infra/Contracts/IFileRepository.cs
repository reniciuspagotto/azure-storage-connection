using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AzureStorage.Infra.Contracts
{
    public interface IFileRepository
    {
        Task<string> Upload(IFormFile file);
    }
}
