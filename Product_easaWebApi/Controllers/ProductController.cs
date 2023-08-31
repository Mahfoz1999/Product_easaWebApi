using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product_Easa_Commends.ProductCommends.Commend;
using Product_Easa_Commends.ProductCommends.Query;
using Product_Easa_Models.Core;

namespace Product_easaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _mediator.Send(new AddProductCommend(product));
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _mediator.Send(new UpdateProductCommend(product));
            return Ok(result);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            var result = await _mediator.Send(new RemoveProductCommend(productId));
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var result = await _mediator.Send(new GetProductQuery(productId));
            return Ok(result);
        }
    }
}
