using System;
using System.Text.RegularExpressions;

public class Program
{
    //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio

    public static string[] ExtraerEtiquetas(string entrada)
    {
        MatchCollection matchea = Regex.Matches(entrada, @"<(?<tag>\w+)>(?<content>.*?)</\k<tag>>", RegexOptions.Singleline);
        var resultado = new string[matchea.Count];

        for (int i = 0; i < matchea.Count; i++)
        {
            resultado[i] = matchea[i].Groups["content"].Value;
        }
        
        return resultado;
    }

    static void Main()
    {
        Console.WriteLine("Ejercicio 4: Extracción de contenido de etiquetas HTML\n");

        Console.Write("Introduce la línea HTML: ");
        string entrada = Console.ReadLine() ?? "";

        string[] etiquetas = ExtraerEtiquetas(entrada);

        Console.Write("El contenido de la línea es: [");
        for (int i = 0; i < etiquetas.Length; i++)
        {
            Console.Write($"\"{etiquetas[i]}\"");
            if (i < etiquetas.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}