namespace MongoAPI.Entities.Product;

public enum Category
{

    Top,
    Dress,
    Bottom,
    Jacket,
    Skirt,
}

public static class CategoryMethods
{
    public static string FromCategoryToString(this Category category) => category switch
    {
        Category.Top => "Top",
        Category.Dress => "Dress",
        Category.Bottom => "Bottom",
        Category.Jacket => "Jacket",
        Category.Skirt => "Skirt",
        _ => "Unknown"
    };
}