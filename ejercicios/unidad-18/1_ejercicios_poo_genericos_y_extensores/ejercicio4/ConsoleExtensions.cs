namespace StringExtensions;

public static class StringExtensions
{
    public static void Gris(this string s) => Console.ForegroundColor = ConsoleColor.Gray;
    public static void Color(this string s, ConsoleColor color) {
        Console.ForegroundColor = color;
    }
}
