using Azure.Storage.Blobs;
using AzureStorage.ApiSample.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
            var connectionString = _configuration["StorageConfiguration:ConnectionString"];
            var containerName = _configuration["StorageConfiguration:ContainerName"];

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            BlobClient blob = container.GetBlobClient(file.FileName);

            await blob.UploadAsync(file.OpenReadStream());

            return blob.Uri.AbsoluteUri.ToString();
        }
    }
}
