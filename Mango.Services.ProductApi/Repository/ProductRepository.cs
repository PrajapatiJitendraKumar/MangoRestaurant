using AutoMapper;
using Mango.Services.ProductApi.DbContexts;
using Mango.Services.ProductApi.Models;
using Mango.Services.ProductApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductApi.Repository;

public class ProductRepository : IProductRepository
{

    private readonly ApplicationDbContext _dbContext;
    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        
        _dbContext = dbContext;
        _mapper = mapper;   
    }
    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
       Product product= _mapper.Map<Product>(productDto);
        if (product.ProductId > 0)
        {
            _dbContext.Products.Update(product);
        }
        else {
            _dbContext.Products.Add(product);
        }
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int ProductId)
    {
        try {
            Product product = await _dbContext.Products.FirstOrDefaultAsync(x=> x.ProductId== ProductId);
            if (product == null) 
            {
                return false; 
            }
            else
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
        catch {
            return false;
        }
    }

    public async Task<ProductDto> GetProductById(int ProductId)
    {
        Product product = await _dbContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        IEnumerable<Product> products = await _dbContext.Products.ToListAsync();
        return  _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
