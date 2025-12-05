using System;
using System.Text.RegularExpressions;

public class Program
{
   //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio
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
