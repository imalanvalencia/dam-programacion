using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
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
