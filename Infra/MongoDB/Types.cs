namespace MongoAPI.Infra.MongoDB;

public class PaginatedResponse<T>
{
    public long total { get; set; }
    public required List<T> items { get; set; }
}