using System.Text.RegularExpressions;
public class FormatoCredentialIncorrectoException(string mensaje) : Exception(mensaje);
public class AccessoDenegadoException(string mensaje) : Exception(mensaje);

public class ControlAcceso
{
    string patronCorrecto = @"[a-zA-Z]+@[a-zA-Z-]{3,}[A-Z]";
    public bool ValidaCredencial(string codigo) => Regex.IsMatch(codigo, patronCorrecto);
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.ReadLine();
        Console.ReadKey();
    }
}