using ApoloApi.DataAccess.Entidades;
using ApoloApiDataAccess.contracts.Dto;
using ApoloApiDataAccess.contracts.Repositories;

namespace ApoloApi.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private ApoloApiDataAccessContext _context;

        public ProductRepository(ApoloApiDataAccessContext context)
        {
            _context = context;
        }

        public ProductDto? GetProductById(string productCode)
        {
            var query =
                from product in _context.Products
                where product.ProductCode == productCode
                select new ProductDto
                {
                    BuyPrice = product.BuyPrice,
                    Msrp = product.Msrp,
                    ProductCode = product.ProductCode,
                    ProductDescription = product.ProductDescription,
                    ProductLine = product.ProductLine,
                    ProductName = product.ProductName,
                    ProductScale = product.ProductScale,
                    ProductVendor = product.ProductVendor,
                    QuantityInStock  = product.QuantityInStock,
                };

            return query.FirstOrDefault();

        }

    }
}
