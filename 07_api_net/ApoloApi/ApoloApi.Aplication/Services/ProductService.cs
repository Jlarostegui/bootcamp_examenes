using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Product;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.Aplication.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public ProductResponse? GetProductResponse(string code)
        {
            ProductDto? product = _ProductRepository.GetProductById(code);
            ProductResponse result = new ProductResponse();
            if(product != null)
            {
                result.Code = product.ProductCode;
                result.Description = product.ProductDescription;
                result.Price = product.BuyPrice;
                result.Stok = product.QuantityInStock;
            }
            else return null;

            return result;
        }
    }
}
