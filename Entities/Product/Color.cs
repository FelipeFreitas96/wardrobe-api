public enum Color
{
    White,
    Red,
    Green,
    Blue,
    Black
}

public static class ColorMethods
{
    public static string FromColorToString(this Color color) => color switch
    {
        Color.White => "White",
        Color.Red => "Red",
        Color.Green => "Green",
        Color.Blue => "Blue",
        Color.Black => "Black",
        _ => "Unknown"
    };
}
