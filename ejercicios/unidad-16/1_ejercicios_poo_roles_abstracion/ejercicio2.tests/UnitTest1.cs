using System;
using System.Collections.Generic;

namespace ejercicio2.tests;

public class TestsEventos
{
    [Fact(DisplayName = "Cita médica horario específico calcula inicio y fin correctos")]
    public void CitaMedicaHorarioEspecifico()
    {
        var inicio = new DateTime(2025,9,10,9,30,0);
        var fin = new DateTime(2025,9,10,10,0,0);
        var evento = new CitaMedica("Consulta Cardiología", new RangoEvento.HorarioEspecifico(inicio, fin), "Av. Salud 15");
        Assert.Equal(inicio, evento.FechaInicio);
        Assert.Equal(fin, evento.FechaFin);
        Assert.Contains("Horario específico", evento.Descripcion);
    }

    [Fact(DisplayName = "Reunión todo el día cubre 24h del día actual")]
    public void ReunionTodoElDia()
    {
        var reunion = new ReunionTrabajo("Reunión", new RangoEvento.TodoElDia(), new List<string>());
        Assert.Equal(DateTime.Today, reunion.FechaInicio.Date);
        Assert.Equal(DateTime.Today, reunion.FechaFin.Date); // fin formateado HH:mm se genera internamente; aquí validamos fecha base
        Assert.Contains("Todo el día", reunion.Descripcion);
    }

    [Fact(DisplayName = "Evento todo el mes inicializa primer y ultimo día correctamente")]
    public void EventoTodoElMes()
    {
        var cita = new CitaMedica("Revisión", new RangoEvento.TodoElMes("septiembre"), "C/ Mayor 22");
        Assert.Equal(9, cita.FechaInicio.Month);
        Assert.Equal(1, cita.FechaInicio.Day);
        Assert.Equal(10, cita.FechaFin.Month);
        Assert.Contains("Todo el mes", cita.Descripcion);
    }

    [Fact(DisplayName = "GestionaEventos imprime eventos con rangos")]
    public void GestionaEventos_MuestraInformacion()
    {
        using var sw = new StringWriter();
        var original = Console.Out;
        Console.SetOut(sw);
        Program.GestionaEventos();
        Console.SetOut(original);
        var salida = sw.ToString();
        Assert.Contains("Ejercicio 2: Gestión de agenda de horarios", salida);
        Assert.Contains("Cita Médica", salida);
        Assert.Contains("Reunión de proyecto", salida);
        Assert.Contains("Todo el mes", salida);
        Assert.Contains("Todo el día", salida);
    }
}
