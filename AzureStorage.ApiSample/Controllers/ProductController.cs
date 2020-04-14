using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Threading.Tasks;

namespace AzureStorage.ApiSample.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file, [FromForm]Product command)
        {
            var imageUrl = await Upload(file);
            command.ImageUrl = imageUrl;
            return Ok(command);
        }

        private async Task<string> Upload(IFormFile file)
        {
            var accountName = _configuration["StorageConfiguration:AccountName"];
            var accountKey = _configuration["StorageConfiguration:AccountKey"];
            var containerName = _configuration["StorageConfiguration:ContainerName"];

            var storageCredentials = new StorageCredentials(accountName, accountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobAzure = storageAccount.CreateCloudBlobClient();
            var container = blobAzure.GetContainerReference(containerName);

            var blob = container.GetBlockBlobReference(file.FileName);
            blob.Properties.ContentType = file.ContentType; // Aqui é definido o tipo do arquivo
            await blob.UploadFromStreamAsync(file.OpenReadStream());

            return blob.SnapshotQualifiedStorageUri.PrimaryUri.ToString();
        }
    }
}
