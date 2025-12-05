using System;
using System.Text.RegularExpressions;

public class Program
{

    //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio


    public static string numeroTarjetaCredito = @"^\d{4}\s?\d{4}\s?\d{4}\s?\d{4}$";
    public static string nombreUsuario = @"^[a-zA-Z][\w.]{3,13}[a-zA-Z\d]$";
    public static string matriculaCoche = @"^\d{4}[B-DF-HJ-NP-TV-Z]{3}$";
    public static string codigoPostal = @"^(0[1-9]|[1-4][\w]|5[0-2])\d{3}$";
    
    public static bool ValidaEntrada(string patron, string entrada)
    {
        if (!Regex.IsMatch(entrada, patron))
        {
            Console.WriteLine($"La entrada '{entrada}' NO es válida.");
            return false;
        }

        Console.WriteLine($"La entrada '{entrada}' es válida.");
        return true;
    }
  
    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 1: Iniciándonos con ER\n");

        Console.WriteLine("=== VALIDACIÓN DE TARJETA DE CRÉDITO ===");
        Console.Write("Introduce un número de tarjeta: ");
        string tarjeta = Console.ReadLine() ?? "";
        ValidaEntrada(numeroTarjetaCredito, tarjeta);
        
        Console.WriteLine("\n=== VALIDACIÓN DE NOMBRE DE USUARIO ===");
        Console.Write("Introduce un nombre de usuario: ");
        string usuario = Console.ReadLine() ?? "";
        ValidaEntrada(nombreUsuario, usuario);
        
        Console.WriteLine("\n=== VALIDACIÓN DE MATRÍCULA ===");
        Console.Write("Introduce una matrícula: ");
        string matricula = Console.ReadLine() ?? "";
        ValidaEntrada(matriculaCoche, matricula);
        
        Console.WriteLine("\n=== VALIDACIÓN DE CÓDIGO POSTAL ===");
        Console.Write("Introduce un código postal: ");
        string cp = Console.ReadLine() ?? "";
        ValidaEntrada(codigoPostal, cp);

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}
