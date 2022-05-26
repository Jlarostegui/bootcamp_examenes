using ApoloApi.Application.contracts.Services;
using ApoloApi.BusinessModels.Models.Product;
using ApoloApiDataAccess.contracts;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.Aplication.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private IUnitOfWork _uOw;

        public ProductService(IProductRepository productRepository,IUnitOfWork uOw)
        {
            _ProductRepository = productRepository;
            _uOw = uOw;
        }

        public ProductResponse? GetProductResponse(string code)
        {
            ProductDto? product = _ProductRepository.GetProductById(code);
            ProductResponse result = new ProductResponse();
            if (product != null)
            {
                result.Code = product.ProductCode;
                result.Description = product.ProductDescription;
                result.Price = product.BuyPrice;
                result.Stok = product.QuantityInStock;
            }
            else return null;

            return result;
        }

        public ProductResponse AddProduct(ProductRequest product)
        {
            ProductDto newProduct = new ProductDto
            {
                BuyPrice = product.Price,
                Msrp = product.Msrp,
                ProductCode = product.Code,
                ProductDescription = product.Description,
                ProductLine = product.Line,
                ProductName = product.Name,
                ProductScale = product.Scale,
                ProductVendor = product.Vendor,
                QuantityInStock = product.QuantityInStock,
            };

            ProductDto productedInserted = _ProductRepository.AddProduct(newProduct);

            _uOw.Commit();

            ProductResponse result = new ProductResponse
            { 
                Code = productedInserted.ProductCode,
                Description = productedInserted.ProductDescription,
                Price = productedInserted.BuyPrice,
                Stok = productedInserted.QuantityInStock
            };
           
            return result;
        }

        public bool DeleteProduct(string productCode)
        {
            ProductDto? product = _ProductRepository.GetProductById(productCode);
            if(product == null)
            {
                //throw new Exception("El producto que desea eliminar no exitse");
                return false;
            }
            else
            {
                _ProductRepository.DeleteProduct(product);
                _uOw.Commit();
                return true;
            }
        }
    }
}
