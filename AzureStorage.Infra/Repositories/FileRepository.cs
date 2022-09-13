using Azure.Storage.Blobs;
using AzureStorage.Infra.Contracts;
using AzureStorage.Infra.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AzureStorage.Infra.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IOptions<StorageConfiguration> _storageConfig;

        public FileRepository(IOptions<StorageConfiguration> storageConfig)
        {
            _storageConfig = storageConfig;
        }

        public async Task<string> Upload(IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(_storageConfig.Value.ConnectionString, _storageConfig.Value.ContainerName);

            BlobClient blob = container.GetBlobClient(file.FileName);

            await blob.UploadAsync(file.OpenReadStream());

            return blob.Uri.AbsoluteUri.ToString();
        }
    }
}
