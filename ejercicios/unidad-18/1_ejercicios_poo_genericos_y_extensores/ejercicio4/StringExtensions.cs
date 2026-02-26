namespace StringExtensions;

public static class StringExtensions
{
    public static void Gris(this string s)
    { 
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine(s);
      Console.ResetColor();
    }

    public static void Color(this string s, ConsoleColor color) 
    {
        Console.ForegroundColor = color;
      Console.WriteLine(s);
      Console.ResetColor();
    }
}
