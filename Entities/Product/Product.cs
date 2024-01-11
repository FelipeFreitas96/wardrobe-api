using MongoAPI.Entities.Product;

public struct ProductEntity
{
    public string? Id { get; set; }
    public string? name { get; set; }
    public float? price { get; set; }
    public int? quantity { get; set; }
}

public struct CreateProductDTO
{
    public Color color { get; set; }
    public Size size { get; set; }
    public Pattern pattern { get; set; }
    public Category category { get; set; }
    public float price { get; set; }
    public int quantity { get; set; }
}