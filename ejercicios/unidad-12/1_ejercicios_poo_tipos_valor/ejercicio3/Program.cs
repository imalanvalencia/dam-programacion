using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
    public static void MuestraFormatosPersonalizados()
    {
        DateTime hoy = DateTime.Today;
        CultureInfo cultura = new("es_ES");

        Console.WriteLine($"""
        === FORMATOS PERSONALIZADOS ===
        Formato corto: {hoy.ToString("d", cultura)}
        Formato largo: {hoy.ToString("D", cultura)}
        Formato ISO 8601: {hoy:O}
        Formato americano: {hoy:G}
        """);
        /* TODO: FALTA TERMINAR 
        Formato europeo: {hoy:d}
        Formato personalizado: "{hoy:d}"  */
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3: Conversor de formatos de fecha y zona horaria\n");

        MuestraFormatosPersonalizados();

        DateTime fechaLocal = new DateTime(2025, 2, 4, 14, 30, 25);
        ConvierteAZonasHorarias(fechaLocal);

        PruebaParsing();

        Console.WriteLine("\nPulsa una tecla para acabar...");
        Console.ReadKey();
    }
}
