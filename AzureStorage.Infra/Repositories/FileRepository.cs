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
            return "url/teste";

            //var storageCredentials = new StorageCredentials(_storageConfig.Value.AccountName, _storageConfig.Value.AccountKey);
            //var storageAccount = new CloudStorageAccount(storageCredentials, true);
            //var blobAzure = storageAccount.CreateCloudBlobClient();
            //var container = blobAzure.GetContainerReference(_storageConfig.Value.ContainerName);
            //var blob = container.GetBlockBlobReference(file.FileName);
            //await blob.UploadFromStreamAsync(file.OpenReadStream());

            //return blob.SnapshotQualifiedStorageUri.PrimaryUri.ToString();
        }
    }
}
