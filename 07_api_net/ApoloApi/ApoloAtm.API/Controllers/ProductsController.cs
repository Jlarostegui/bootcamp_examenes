using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ApoloAtm.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]

    public class ProductsController : Controller
    {

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("{code}")]
        public IActionResult GetProductByCode(string code)
        {
            ProductResponse? product = _productService.GetProductResponse(code);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Addproduct(ProductRequest product)
        {
            ProductResponse? newProduct = _productService.AddProduct(product);
            return Ok(newProduct);
        }

        [HttpDelete]
        [Route("{code}")]
        public IActionResult DeleteProduct(string code)
        {
            bool resukt = _productService.DeleteProduct(code);

            if (resukt)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("El producto no existe");
            }

        }

        [HttpPut]
        [Route("{code}")]
        public IActionResult UpdatedProduct(string code ,ProductUpdateRequest product)
        {
            ProductResponse productUpdated = _productService.UpdateProduct(code, product);
            return Ok(productUpdated);
        }

    
    }
}
