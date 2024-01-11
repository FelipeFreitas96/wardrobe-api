using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoAPI.Models;
using MongoAPI.Infra.MongoDB;
using System.Text.RegularExpressions;

namespace MongoAPI.Repository;

public class ProductRepository
{
    private readonly IMongoCollection<ProductsModel> _productsCollection;
    public ProductRepository(IOptions<MongoSettingsEntity> settings)
    {
        MongoClient client = new MongoClient(settings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase("local");
        _productsCollection = database.GetCollection<ProductsModel>("products");
    }

    public async Task<ProductEntity> GetProductById(string id)
    {
        ProductsModel product = await _productsCollection.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        return product.ToProductEntity();
    }

    public async Task<PaginatedResponse<ProductEntity>> GetProducts(int Page, int PageSize, int? Category, string? SearchString)
    {
        FilterDefinition<ProductsModel> filter = new BsonDocument();

        if (SearchString != null && SearchString.Length > 0)
        {
            filter = filter & Builders<ProductsModel>.Filter.Regex(
                    x => x.name,
                    new BsonRegularExpression(new Regex(SearchString, RegexOptions.IgnoreCase))
                );
        }

        if (Category != null)
        {
            filter = filter & Builders<ProductsModel>.Filter.Eq(
                "category",
                Category
            );
        }

        long total = await _productsCollection.CountDocumentsAsync(filter);
        List<ProductsModel> products = await _productsCollection.Find(filter).Skip(Page).Limit(PageSize).ToListAsync();
        List<ProductEntity> items = new List<ProductEntity>();

        for (int i = 0; i < products.Count; i++)
        {
            items.Add(products[i].ToProductEntity());
        }

        return new PaginatedResponse<ProductEntity>
        {
            total = total,
            items = items,
        };
    }

    public async Task DeleteProduct(string id)
    {
        await _productsCollection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
    }

    public async Task<ProductEntity> CreateProduct(CreateProductDTO product)
    {
        string Id = ObjectId.GenerateNewId().ToString();
        ProductsModel productModel = new ProductsModel
        {
            category = product.category,
            pattern = product.pattern,
            price = product.price,
            quantity = product.quantity,
            color = product.color,
            Id = Id,
        };

        await _productsCollection.InsertOneAsync(productModel.GenerateName());
        ProductEntity response = await GetProductById(Id);
        return response;
    }
}