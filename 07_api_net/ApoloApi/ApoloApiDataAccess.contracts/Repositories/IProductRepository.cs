using ApoloApiDataAccess.contracts.Dto;

namespace ApoloApiDataAccess.contracts.Repositories
{
    public interface IProductRepository
    {

        public ProductDto? GetProductById(string productCode);

    }
}
