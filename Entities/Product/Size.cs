namespace MongoAPI.Entities.Product;

public enum Size
{
    XS,
    S,
    M,
    L,
    XL,
    XXL,
}

public static class SizeMethods
{
    public static string FromSizeToString(this Size size) => size switch
    {
        Size.XS => "XS",
        Size.S => "S",
        Size.M => "M",
        Size.L => "L",
        Size.XL => "XL",
        Size.XXL => "XXL",
        _ => "Unknown"
    };
}