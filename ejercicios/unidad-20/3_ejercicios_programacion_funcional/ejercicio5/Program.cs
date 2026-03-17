using System.Formats.Asn1;
using System.Text.RegularExpressions;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 5. Recursividad con Lambdas\n");

        Func<int, int> sumatorio = default;
        Func<int, int> sumaDigitos = default;
        Func<string, int> cuentaVocales = default;

        Console.Write("Sumatorio de 1 a \"5\":");
        //A completar
        Console.WriteLine(sumatorio(5));
        Console.Write("Suma de dígitos del número \"543\":");
        //A completar
        Console.WriteLine(sumaDigitos(543));
        Console.Write("Cuenta de vocales en la cadena \"Hola MUNDO\":");
        //A completar
        Console.WriteLine(cuentaVocales("Hola MUNDO"));

        Console.ReadLine();

    }
}