using System;
using System.Text.RegularExpressions;

public class Program
{
    //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio
    public static string patronCIF = @"^(?<tipo>[A-HK-NP-SU-W])[\s-]?(?<provincia>\d{2})(?<secuencial>\d{5})[\s-]?(?<control>[0-9A-J])$";

    public static void CompruebaCif(string cif)
    {
        Match match = Regex.Match(cif, patronCIF);

        if (!match.Success)
        {
            Console.WriteLine($"CIF no válido: {cif}");
            return;
        }

        Console.WriteLine(
        @$"CIF válido: {cif}
        - Tipo de organización: {match.Groups["tipo"].Value}
        - Código provincial: {match.Groups["provincia"].Value}
        - Numeración secuencial: {match.Groups["secuencial"].Value}
        - Dígito de control: {match.Groups["control"].Value}"
        );
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Validación de CIF\n");

        Console.Write("Introduce un CIF: ");
        string cif = Console.ReadLine() ?? "";

        CompruebaCif(cif);

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}
