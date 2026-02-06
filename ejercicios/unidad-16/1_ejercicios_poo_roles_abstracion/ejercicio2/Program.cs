
using System;
using System.Collections.Generic;
using System.Globalization;


public abstract record RangoEvento
{
    public record TodoElDia : RangoEvento;
    public record HorarioEspecifico(DateTime inicio, DateTime fin) : RangoEvento;
    public record TodoElMes(string nombreMes) : RangoEvento;
}

public abstract class EventoAgenda
{
    public string Descripcion { get; }
    public DateTime FechaInicio { get; }
    public DateTime FechaFin { get; }

    public EventoAgenda(string descripcion, RangoEvento rango)
    {


        (FechaInicio, FechaFin, string aclaracion) = rango switch
        {
            RangoEvento.TodoElDia =>
                (DateTime.Today, DateTime.Today.AddDays(1).AddMinutes(-1), "Todo el día"),

            RangoEvento.HorarioEspecifico horario =>
                (horario.inicio, horario.fin, $"Horario específico"),

            RangoEvento.TodoElMes mes =>
                (ParseaMes(mes.nombreMes),
                 ParseaMes(mes.nombreMes).AddMonths(1),
                    $"Todo el mes de {mes.nombreMes}"),
            _ => (DateTime.MinValue, DateTime.MinValue, "Rango no válido")
        };


        Descripcion = $"{descripcion} - {aclaracion}";
    }

    private DateTime ParseaMes(string nombreMes) => new(DateTime.Today.Year, DateTime.Parse($"{nombreMes}/{DateTime.Today.Year}", new CultureInfo("es_ES")).Month, 1);


    public abstract string DescripcionEvento();

    public override string ToString()
    {
        return $"Evento -> Desde: {FechaInicio:yyyy-MM-dd HH:mm}, Hasta: {FechaFin:yyyy-MM-dd HH:mm} - {DescripcionEvento()} - {Descripcion}";
    }
}


public class CitaMedica : EventoAgenda
{
    public string Direccion { get; }

    public CitaMedica(string descripcion, RangoEvento rango, string direccion)
        : base(descripcion, rango)
    {
        Direccion = direccion;
    }

    public override string DescripcionEvento() => "Cita Médica";

    public override string ToString()
    {
        return base.ToString() + $"\n    Dirección: {Direccion}";
    }
}


public class ReunionTrabajo : EventoAgenda
{
    public List<string> Asistentes { get; }

    public ReunionTrabajo(string descripcion, RangoEvento rango, List<string> asistentes)
        : base(descripcion, rango)
    {
        Asistentes = asistentes;
    }

    public override string DescripcionEvento() => "Reunión";

    public override string ToString()
    {
        string asistentesStr = string.Join(", ", Asistentes);
        return base.ToString() + $"\n    Asistentes: {asistentesStr}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GestionaEventos();
        Console.ReadKey();
    }

    public static void GestionaEventos()
    {
        Console.WriteLine("Ejercicio 2: Gestión de agenda de horarios\n\nCreando eventos...\n");


        List<EventoAgenda> eventos = [];

        CitaMedica citaMedicaHorario = new(
            "Consulta Cardiología",
            new RangoEvento.HorarioEspecifico(
                new DateTime(2025, 9, 10, 9, 30, 0),
                new DateTime(2025, 9, 10, 10, 0, 0)
            ),
            "Av. de la Salud, 15"
        );
        eventos.Add(citaMedicaHorario);

        ReunionTrabajo reunionTodoDia = new(
            "Reunión de proyecto",
            new RangoEvento.TodoElDia(),
            ["Ana", "Juan", "Marta"]
        );
        eventos.Add(reunionTodoDia);


        CitaMedica citaMedicaMes = new(
            "Consulta Revisión mensual",
            new RangoEvento.TodoElMes("Septiembre"),
            "C/ Mayor, 22"
        );
        eventos.Add(citaMedicaMes);


        Console.WriteLine("Evento: CitaMedica\n");
        foreach (var evento in eventos)
        {
            Console.WriteLine($"  - {evento}\n");
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
    }
}