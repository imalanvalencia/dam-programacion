using System;
using System.Globalization;

public class Program
{
    //TODO: Implementa la lógica necesaria para solucionar el ejercicio
    public static void CalculaEdad(DateTime fechaNacimiento)
    {
        DateTime hoy = DateTime.Today;
        int diasHastaHoy = (hoy - fechaNacimiento).Days;

        // 1️⃣ Calcular años y días completos
        int años = hoy.Year - fechaNacimiento.Year;
        int dias = hoy.Day - fechaNacimiento.Day;

        if (dias < 0) dias += DateTime.DaysInMonth(hoy.AddMonths(-1).Year, hoy.AddMonths(-1).Month);

        // 2️⃣ Próximo cumpleaños
        DateTime proximoCumple = new(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);
        if (proximoCumple < hoy) proximoCumple = proximoCumple.AddYears(1);

        int diasParaCumple = (proximoCumple - hoy).Days;

        Console.WriteLine($"""
        === CÁLCULOS CON DATETIME ===
        Fecha de nacimiento: {fechaNacimiento.Date}
        Cálculos desde tu nacimiento:
        - Días vividos: {diasHastaHoy} días
        - Años completos: {años} años y {dias} días
        - Próximo cumpleaños: {proximoCumple:dd/MM/yyyy} (en {diasParaCumple} días)
        - Día de la semana que naciste: {fechaNacimiento.ToString("dddd", new CultureInfo("es-ES"))}
        """);
    }

    public static void CalculaJornadaLaboral()
    {
        Console.Write("Introduce la hora de inicio de la jornada: ");
        TimeOnly.TryParse(Console.ReadLine(), out TimeOnly inicioJornada);

        Console.Write("Introduce la hora de fin de la jornada: ");
        TimeOnly.TryParse(Console.ReadLine(), out TimeOnly finJornada);

        Console.Write("Introduce la hora de inicio del descanso: ");
        TimeOnly.TryParse(Console.ReadLine(), out TimeOnly inicioDescanso);

        Console.Write("Introduce la duración del descanso (en minutos): ");

        TimeOnly duracionDescanso = new(0, 0);

        if (int.TryParse(Console.ReadLine(), out int minutosDescanso))
        {
            duracionDescanso = new(0, minutosDescanso);
        }

        TimeOnly finDescanso = inicioDescanso.Add(duracionDescanso.ToTimeSpan());
        TimeSpan duracionJornada = finJornada.ToTimeSpan() - inicioJornada.ToTimeSpan();

        TimeSpan jornadaEfectiva = finJornada.ToTimeSpan() - inicioJornada.ToTimeSpan() - duracionDescanso.ToTimeSpan();
        TimeSpan horasSemanales = jornadaEfectiva * 5;


        Console.WriteLine($"""
        === CÁLCULOS CON TimeOnly ===
        Hora de inicio trabajo: {inicioJornada}
        Hora de fin trabajo: {finJornada}
        Duración jornada laboral: {duracionJornada}

        Hora de inicio descanso: {inicioDescanso}
        Duración del descanso: {duracionDescanso}
        Hora de fin descanso: {finDescanso}

        Tiempo trabajado efectivo: {jornadaEfectiva}
        Horas trabajadas en la semana (5 días): {horasSemanales:hh\:mm\:ss}
        """);
    }


    public static void MuestraComparaciones()
    {
        return;
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
