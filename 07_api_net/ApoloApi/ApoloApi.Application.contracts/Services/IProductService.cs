﻿using ApoloApi.BusinessModels.Models.Product;

namespace ApoloApi.Application.contracts.Services
{
    public interface IProductService
    {
        ProductResponse? GetProductResponse(string code);
    }
}