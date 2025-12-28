using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
    public static void MuestraFormatosPersonalizados()
    {
        DateTime ahora = DateTime.Now;
        CultureInfo cultura = CultureInfo.GetCultureInfo("es-ES");

        Console.WriteLine($"""
        === FORMATOS PERSONALIZADOS ===
        Formato corto: {ahora.ToString("d", cultura)}
        Formato largo: {ahora.ToString("D", cultura)}
        Formato ISO 8601: {ahora:yyyy-MM-ddTHH:mm:ss}
        Formato americano: {ahora.ToString("MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}
        Formato europeo: {ahora.ToString("dd.MM.yyyy HH:mm:ss")}
        Formato personalizado: "El día {ahora:dd} de {ahora:MMMM, CultureInfo.InvariantCulture} del año {ahora:yyyy} a las {ahora:HH} horas y {ahora:mm} minutos"
        """);
    }

    public static void ConvierteAZonasHorarias(DateTime fechaLocal)
    {
        Console.WriteLine("=== CONVERSIONES DE ZONA HORARIA ===");
        Console.WriteLine($"Hora local (Madrid): {fechaLocal:dd/MM/yyyy HH:mm:ss}");
        
        var zonas = new[]
        {
            ("Londres (UTC+0)", -1),
            ("Nueva York (UTC-5)", -6),
            ("Tokio (UTC+9)", 8)
        };

        foreach (var (nombre, offset) in zonas)
        {
            DateTime fechaConvertida = fechaLocal.AddHours(offset);
            Console.WriteLine($"En {nombre}: {fechaConvertida:dd/MM/yyyy HH:mm:ss}");
        }
    }

    public static void PruebaParsing()
    {
        Console.WriteLine("=== PARSING DE FECHAS ===");
        
        Console.Write("Introduce fecha en formato dd/MM/yyyy: ");
        string? input1 = Console.ReadLine();
        if (DateTime.TryParseExact(input1, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime resultado1))
        {
            Console.WriteLine($"Fecha parseada: {resultado1:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("¿Es válida? True");
        }
        else
        {
            Console.WriteLine("¿Es válida? False");
            Console.WriteLine("Error: El formato de fecha no es válido.");
        }

        Console.Write("Introduce fecha en formato MM-dd-yyyy: ");
        string? input2 = Console.ReadLine();
        if (DateTime.TryParseExact(input2, "MM-dd-yyyy", null, DateTimeStyles.None, out DateTime resultado2))
        {
            Console.WriteLine($"Fecha parseada: {resultado2:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("¿Es válida? True");
        }
        else
        {
            Console.WriteLine("¿Es válida? False");
            Console.WriteLine("Error: El formato de fecha no es válido.");
        }

        Console.Write("Introduce fecha en formato inválido: ");
        string? input3 = Console.ReadLine();
        if (DateTime.TryParseExact(input3, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime resultado3))
        {
            Console.WriteLine($"Fecha parseada: {resultado3:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("¿Es válida? True");
        }
        else
        {
            Console.WriteLine("¿Es válida? False");
            Console.WriteLine("Error: El formato de fecha no es válido.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 3: Conversor de formatos de fecha y zona horaria\n");

        MuestraFormatosPersonalizados();

        DateTime fechaLocal = new DateTime(2025, 2, 4, 14, 30, 25);
        ConvierteAZonasHorarias(fechaLocal);

        PruebaParsing();

        Console.WriteLine("Pulsa una tecla para acabar...");
        try
        {
            Console.ReadKey();
        }
        catch (InvalidOperationException)
        {
            // Console input redirected - just exit
        }
    }
}
