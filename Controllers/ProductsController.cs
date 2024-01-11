using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Infra.MongoDB;

namespace wardrobe_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly MongoAPI.Repository.ProductRepository _database;

    public ProductsController(MongoAPI.Repository.ProductRepository database)
    {
        _database = database;
    }

    [HttpGet]
    public async Task<PaginatedResponse<ProductEntity>> GetProducts([FromQuery] int Page, [FromQuery] int PageSize, [FromQuery] int? Category, [FromQuery] string? q)
    {
        return await _database.GetProducts(Page, PageSize, Category, q);
    }

    [HttpGet("{id}")]
    public async Task<ProductEntity> GetProductById(string id)
    {
        return await _database.GetProductById(id);
    }

    [HttpPost]
    public async Task<ProductEntity> CreateProduct([FromBody] CreateProductDTO product)
    {
        return await _database.CreateProduct(product);
    }

    [HttpDelete("{id}")]
    public async Task DeleteProduct(string id)
    {
        await _database.DeleteProduct(id);
    }
}
