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
        Horas trabajadas en la semana (5 días): {(int)horasSemanales.TotalHours}:{horasSemanales:mm\:ss}
        """);
    }


    static string FormateaFecha(DateTime fecha, CultureInfo? cultura = null)
    {
        cultura ??= new CultureInfo("es-ES");
        return fecha.ToString("d 'de' MMMM", cultura);
    }

    public static void MuestraComparaciones()
    {
        CultureInfo cultura = new("es-ES");

        DateTime fecha1 = new(2025, 3, 15, 8, 30, 0);
        DateTime fecha2 = new(2025, 7, 31, 17, 45, 0);

        // Extraemos las horas directamente de las fechas
        TimeOnly hora1 = TimeOnly.FromDateTime(fecha1);
        TimeOnly hora2 = TimeOnly.FromDateTime(fecha2);

        // Fin de año del mismo año que fecha2
        DateTime finDeAnio = new(fecha2.Year, 12, 31);
        int diasHastaFinDeAnio = (finDeAnio - fecha2.Date).Days;

        Console.WriteLine($"""
    === COMPARACIONES TEMPORALES ===
    Fecha 1: {fecha1.ToString("dd/MM/yyyy HH:mm:ss", cultura)}
    Fecha 2: {fecha2.ToString("dd/MM/yyyy HH:mm:ss", cultura)}

    ¿El {FormateaFecha(fecha1)} es antes que el {FormateaFecha(fecha2)}? {fecha1 < fecha2}
    ¿El {FormateaFecha(fecha1)} es después que el {FormateaFecha(fecha2)}? {fecha1 > fecha2}
    ¿Ambas fechas son iguales? {fecha1 == fecha2}
    ¿Las fechas son distintas? {fecha1 != fecha2}

    Comparación usando CompareTo():
    {FormateaFecha(fecha1)}.CompareTo({FormateaFecha(fecha2)}): {fecha1.CompareTo(fecha2)}
    Fecha 2.CompareTo({FormateaFecha(fecha1)}): {fecha2.CompareTo(fecha1)}

    ¿Las {fecha1.ToString("HH:mm", cultura)} es antes que las {fecha2.ToString("HH:mm", cultura)}? {hora1 < hora2}
    ¿Quedan más de 100 días para fin de año? {diasHastaFinDeAnio > 100}
    """);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio 2: Calculadora de tiempo y fechas\n");

        DateTime fechaActual = DateTime.Now;
        DateOnly fechaSolo = DateOnly.FromDateTime(fechaActual);
        TimeOnly horaSolo = TimeOnly.FromDateTime(fechaActual);

        // Console.WriteLine("=== INFORMACIÓN FECHA ACTUAL ===\n");
        // Console.WriteLine($"Fecha actual: {fechaActual.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"))}");
        // Console.WriteLine($"Hora actual: {horaSolo}");
        // Console.WriteLine($"Fecha solo: {fechaSolo:dd/MM/yyyy}");
        // Console.WriteLine($"Hora solo: {horaSolo}");

        // Console.Write("\nIntroduce tu fecha de nacimiento (dd/MM/yyyy): ");
        // string inputFecha = Console.ReadLine() ?? "15/03/1995";
        // DateTime fechaNacimiento = DateTime.ParseExact(inputFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        // Console.WriteLine();
        // CalculaEdad(fechaNacimiento);
        // Console.WriteLine("\nVamos a calcular la jornada laboral...   ");
        // CalculaJornadaLaboral();

        Console.WriteLine("\nVamos a mostrar comparaciones temporales...   ");
        MuestraComparaciones();

        Console.WriteLine("\nPulsa una tecla para acabar...");
        Console.ReadKey();
    }
}
