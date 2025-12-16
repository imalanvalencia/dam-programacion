using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
    public static void CalculaEdad(DateTime fechaNacimiento)
    {
        DateTime hoy = DateTime.Today;
        TimeSpan diasHastaHoy = hoy - fechaNacimiento;

        // 1️⃣ Calcular años, meses y días completos
        int años = hoy.Year - fechaNacimiento.Year;
        int meses = hoy.Month - fechaNacimiento.Month;
        int dias = hoy.Day - fechaNacimiento.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(hoy.AddMonths(-1).Year, hoy.AddMonths(-1).Month);
        }

        if (meses < 0)
        {
            años--;
            meses += 12;
        }

        // 2️⃣ Próximo cumpleaños
        DateTime proximoCumple = new(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);
        if (proximoCumple < hoy)
            proximoCumple = proximoCumple.AddYears(1);

        int diasParaCumple = (proximoCumple - hoy).Days;

        Console.WriteLine($"""
        === CÁLCULOS CON DATETIME ===
        Fecha de nacimiento: {fechaNacimiento.Date}
        Cálculos desde tu nacimiento:
        - Días vividos: {diasHastaHoy.Days} días
        - Años completos: {años} años y {dias} días
        - Próximo cumpleaños: {proximoCumple:dd/MM/yyyy} (en {diasParaCumple} días)
        - Día de la semana que naciste: {fechaNacimiento.DayOfWeek}
        """);
    }

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

        // Console.Write("\nIntroduce tu fecha de nacimiento (dd/MM/yyyy): ");
        // string inputFecha = Console.ReadLine() ?? "15/03/1995";
        // DateTime fechaNacimiento = DateTime.ParseExact(inputFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        // Console.WriteLine();
        // CalculaEdad(fechaNacimiento);
        // Console.WriteLine("\nVamos a calcular la jornada laboral...   ");
        // CalculaJornadaLaboral();

        // Console.WriteLine("\nVamos a mostrar comparaciones temporales...   ");
        // MuestraComparaciones();

        // Console.WriteLine("\nPulsa una tecla para acabar...");
        // Console.ReadKey();
    }
}
