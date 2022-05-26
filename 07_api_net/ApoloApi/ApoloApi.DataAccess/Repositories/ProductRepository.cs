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

        public ProductDto AddProduct(ProductDto product)
        {
            Product newProduct = new Product
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock,

            };

            var productInserted = _context.Products.Add(newProduct);

            ProductDto result = new ProductDto
            {
                BuyPrice = productInserted.Entity.BuyPrice,
                Msrp = productInserted.Entity.Msrp,
                ProductCode = productInserted.Entity.ProductCode,
                ProductDescription = productInserted.Entity.ProductDescription,
                ProductLine = productInserted.Entity.ProductLine,
                ProductName = productInserted.Entity.ProductName,
                ProductScale = productInserted.Entity.ProductScale,
                ProductVendor = productInserted.Entity.ProductVendor,
                QuantityInStock = productInserted.Entity.QuantityInStock

            };

            return result;

        }

        public void DeleteProduct(ProductDto product)
        {   
            Product productToDelete = new Product
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock,

            };
            _context.Products.Remove(productToDelete);
        }

    }
}
