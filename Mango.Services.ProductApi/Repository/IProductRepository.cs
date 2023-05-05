﻿using Mango.Services.ProductApi.Models.Dto;

namespace Mango.Services.ProductApi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int ProductId);
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int ProductId);
}