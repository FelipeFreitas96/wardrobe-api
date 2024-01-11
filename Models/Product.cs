using MongoAPI.Entities.Product;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models;

public class ProductsModel
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string name { get; set; }
    public Color color { get; set; }
    public Size size { get; set; }
    public Pattern pattern { get; set; }
    public Category category { get; set; }
    public float price { get; set; }
    public int quantity { get; set; }
}

public static class ProductsModelMethods
{
    public static ProductsModel GenerateName(this ProductsModel product)
    {
        product.name = string.Concat(
            product.color.FromColorToString(),
            " ",
            product.pattern.FromPatternToString(),
            " ",
            product.category.FromCategoryToString(),
            " ",
            product.size.FromSizeToString()
        );
        return product;
    }
    
    public static ProductEntity ToProductEntity(this ProductsModel product) => new ProductEntity
    {
        Id = product.Id,
        name = product.name,
        price = product.price,
        quantity = product.quantity,
    };
}