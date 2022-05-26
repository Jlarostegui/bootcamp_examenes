using ApoloApi.BusinessModels.Models.Product;

namespace ApoloApi.Application.contracts.Services
{
    public interface IProductService
    {
        ProductResponse? GetProductResponse(string code);
        ProductResponse? AddProduct(ProductRequest product);
        bool DeleteProduct(string productCode);
    }
}
