using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{

    static string NumberToString(Match m) => m.Value switch 
    {
        "1" => "uno",
        "2" => "dos",
        "3" => "tres",
        "4" => "cuatro",
        "5" => "cinco",
        "6" => "seis",
        "7" => "siete",
        "8" => "ocho",
        "9" => "nueve",
        _ => "cero"
    };



public static string ReescribeTiko(string frase)
{
    frase = Regex.Replace(frase, @"(j[aeiou]){2,}", "😂", RegexOptions.IgnoreCase);

    frase = Regex.Replace(frase, @"\bx q\b", "por qué", RegexOptions.IgnoreCase);

    frase = Regex.Replace(frase, @"([a-km-qs-z])\1+", "$1", RegexOptions.IgnoreCase);
    frase = Regex.Replace(frase, @"([rl])\1{2,}", "$1$1", RegexOptions.IgnoreCase);

    frase = Regex.Replace(frase, @"\d", NumberToString);
    
    
    return frase;
}
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Ejercicio 1: Iniciándonos con ER");
        Console.Write("Introduce una frase: ");
        string entrada = "jajajaja tengo 2 perros y holaaa x q no vienes?";
        Console.WriteLine(entrada);
        string resultado = ReescribeTiko(entrada);
        Console.WriteLine("Frase transformada al lenguaje Tiko:");
        Console.WriteLine(resultado);

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}
