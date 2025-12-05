using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static string ReescribeTiko(string frase)
    {
        //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio
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
