using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Calculadora de tiempo y fechas\n");

        DateTime fechaActual = DateTime.Now;
        DateOnly fechaSolo = DateOnly.FromDateTime(fechaActual);
        TimeOnly horaSolo = TimeOnly.FromDateTime(fechaActual);

        Console.WriteLine("=== INFORMACIÓN FECHA ACTUAL ===\n");
        Console.WriteLine($"Fecha actual: {fechaActual.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"))}");
        Console.WriteLine($"Hora actual: {horaSolo}");
        Console.WriteLine($"Fecha solo: {fechaSolo:dd/MM/yyyy}");
        Console.WriteLine($"Hora solo: {horaSolo}");

        Console.Write("\nIntroduce tu fecha de nacimiento (dd/MM/yyyy): ");
        string inputFecha = Console.ReadLine() ?? "15/03/1995";
        DateTime fechaNacimiento = DateTime.ParseExact(inputFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine();
        CalculaEdad(fechaNacimiento);
        Console.WriteLine("\nVamos a calcular la jornada laboral...   ");
        CalculaJornadaLaboral();
        
        Console.WriteLine("\nVamos a mostrar comparaciones temporales...   ");
        MuestraComparaciones();

        Console.WriteLine("\nPulsa una tecla para acabar...");
        Console.ReadKey();
    }
}
