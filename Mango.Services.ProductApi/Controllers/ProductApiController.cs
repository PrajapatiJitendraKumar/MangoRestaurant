using Mango.Services.ProductApi.Models.Dto;
using Mango.Services.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductApi.Controllers;
[Route("api/products")]
public class ProductApiController : ControllerBase
{
    private IProductRepository _productRepository;
    protected ResponseDto _responseDto;
    public ProductApiController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        this._responseDto = new ResponseDto();
    }



    [HttpGet]
    public async Task<object> Get()
    {
        try 
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _responseDto.Result = productDtos.ToList();
        }
        catch(Exception ex)
        {
        _responseDto.IsSuccess = false;
            _responseDto.Errors = new List<string>() { ex.Message };
        }
        return _responseDto;
    }

}
