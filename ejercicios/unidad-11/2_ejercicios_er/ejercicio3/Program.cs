using System;
using System.Text.RegularExpressions;

public class Program
{

    

    static void Main()
    {
        string textoLogs = @"[2025-07-28 12:34:56] INFO: Inicio
[2025-07-28 12:35:00] ERROR: Fallo de conexión
[2025-07-28 12:36:00] WARN: Memoria baja
[2025-07-28 12:37:00] INFO: Fin";

        Console.WriteLine("Ejercicio 3: Análisis de Logs\n");
        Console.WriteLine("Texto de logs:");
        Console.WriteLine(textoLogs);
        Console.WriteLine("\nResultados:");
        AnalizaLogs(textoLogs);
        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}