using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApiDataAccess.contracts.Repositories
{
    public interface IProductRepository
    {

        ProductDto? GetProductById(string productCode);
        ProductDto AddProduct(ProductDto product);
        void DeleteProduct(ProductDto product);
        ProductDto UpdateProduct(ProductDto product);


    }
}
