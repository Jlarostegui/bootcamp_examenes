using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloApi.BusinessModels.Models.Product
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; } = null!;
        public string Line { get; set; } = null!;
        public string Scale { get; set; } = null!;
        public string Vendor { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public decimal Msrp { get; set; }
    }
}
