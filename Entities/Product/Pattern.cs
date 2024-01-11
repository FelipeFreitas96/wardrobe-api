namespace MongoAPI.Entities.Product;

public enum Pattern
{
    Solid,
    Striped,
    Printed,
    Plaid,
    Dotted,
}

public static class PatternMethods
{
    public static string FromPatternToString(this Pattern pattern) => pattern switch
    {
        Pattern.Solid => "Solid",
        Pattern.Striped => "Striped",
        Pattern.Printed => "Printed",
        Pattern.Plaid => "Plaid",
        Pattern.Dotted => "Dotted",
        _ => "Unknown"
    };
}