using UnitTestTutorial.Api.Controllers.v1.Products.Requests;
using UnitTestTutorial.ApiFramework.Tools;
using UnitTestTutorial.Application.Products.Command.AddProduct;
using UnitTestTutorial.Application.Products.Query.GetProductById;
using UnitTestTutorial.Application.Products.Query.GetProducts;
using UnitTestTutorial.Application.Products.Query.ReadProductFromRedis;
using UnitTestTutorial.Common.Utilities;
using UnitTestTutorial.Domain.Entities.Products;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace UnitTestTutorial.Api.Controllers.v1.Products
{
    [ApiVersion("1")]
    public class ProductController : BaseControllerV1
    {
        [HttpPost]
        [SwaggerOperation("add a product")]
        public async Task<IActionResult> AddAsync([FromBody] AddProductRequest request)
        {
            var command = request.Adapt<AddProductCommand>();

            var result = await Mediator.Send(command);

            return new ApiResult<int>(result);
        }

        [HttpGet]
        [SwaggerOperation("get a product by id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int productId)
        {
            var result = await Mediator.Send(new GetProductByIdQuery { ProductId = productId });
            return new ApiResult<ProductQueryModel>(result);
        }

        [HttpGet("all")]
        [SwaggerOperation("get all products")]
        public async Task<IActionResult> GetAllAsync(GetProductsRequest request)
        {
            var query = request.Adapt<GetProductsQuery>();

            var result = await Mediator.Send(query);
            return new ApiResult<PagedResult<Product>>(result);
        }

        [HttpGet("cache-redis")]
        [SwaggerOperation("get a product from cache. this is a example for how to use cache")]
        public async Task<IActionResult> ReadFromCacheAsync([FromQuery] int productId)
        {
            var result = await Mediator.Send(new ReadProductFromRedisQuery(productId));
            return new ApiResult<ReadProductFromRedisResponse>(result);
        }
    }
}