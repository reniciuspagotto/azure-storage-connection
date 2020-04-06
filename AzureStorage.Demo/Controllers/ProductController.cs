using AzureStorage.Demo.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureStorage.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public async Task<IActionResult> Save([FromBody] Product product, )
        {

        }
    }
}
