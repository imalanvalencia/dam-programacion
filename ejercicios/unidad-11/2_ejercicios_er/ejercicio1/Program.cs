using System;
using System.Text.RegularExpressions;

public class Program
{

    //TODO: Completa el código necesarios para cumplir con las expecificaciones del ejercicio
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
