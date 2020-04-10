using AzureStorage.Core.Commands;
using AzureStorage.Core.Contracts;
using AzureStorage.Core.Handles;
using AzureStorage.Infra.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureStorage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductHandle _productHandler;
        private readonly IFileRepository _fileService;
        private readonly IProductRepository _productRepository;

        public ProductController(ProductHandle productHandler, IFileRepository fileService, IProductRepository productRepository)
        {
            _productHandler = productHandler;
            _fileService = fileService;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file, [FromForm]ProductCreateCommand command)
        {
            var imageUrl = await _fileService.Upload(file);
            command.ImageUrl = imageUrl;

            var result = _productHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Task.FromResult(Ok(_productRepository.GetAll()));
        }
    }
}
