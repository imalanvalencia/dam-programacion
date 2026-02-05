using System;
using System.IO;

namespace ejercicio1.tests;

public class TestsPersonalCuidados
{
    private static DateTime FechaHora(int hour, int minute, int second = 0) => new DateTime(2025, 9, 1, hour, minute, second);

    private static void AssertSalidaGestionaTurnoExacta(PersonalCuidados personal, TimeSpan horaTarea, string descripcionEsperada)
    {
        string salida = personal.GestionaTurno(FechaHora(horaTarea.Hours, horaTarea.Minutes, horaTarea.Seconds));
        Assert.Equal($"[{horaTarea:hh\\:mm}] {descripcionEsperada}", salida);
    }

    private static void AssertToStringContieneTarea(PersonalCuidados personal, TimeSpan horaTarea, string descripcionEsperada)
    {
        string salida = personal.ToString();
        Assert.Contains($"[{horaTarea:hh\\:mm}] {descripcionEsperada}", salida);
    }

    [Fact(DisplayName = "Enfermero: AñadeTareaTurno(TimeSpan,string) prefija descripción")]
    public void Enfermero_AnadeTareaTurno_TimeSpan_PrefijaDescripcion()
    {
        var enfermero = new Enfermero("Ana", "Noche", 10);
        enfermero.AñadeTareaTurno(new TimeSpan(8, 0, 0), "Entrega de turno");

        AssertSalidaGestionaTurnoExacta(enfermero, new TimeSpan(8, 0, 0), "Enfermero: Entrega de turno");
        AssertToStringContieneTarea(enfermero, new TimeSpan(8, 0, 0), "Enfermero: Entrega de turno");
    }

    [Fact(DisplayName = "Enfermero: AñadeTareaTurno(TareaTurno) prefija descripción")]
    public void Enfermero_AnadeTareaTurno_TareaTurno_PrefijaDescripcion()
    {
        var enfermero = new Enfermero("Ana", "Noche", 10);
        enfermero.AñadeTareaTurno(new TareaTurno(new TimeSpan(3, 0, 0), "Emergencias"));

        AssertSalidaGestionaTurnoExacta(enfermero, new TimeSpan(3, 0, 0), "Enfermero: Emergencias");
        AssertToStringContieneTarea(enfermero, new TimeSpan(3, 0, 0), "Enfermero: Emergencias");
    }

    [Fact(DisplayName = "Cuidador: AñadeTareaTurno(TimeSpan,string) prefija descripción")]
    public void Cuidador_AnadeTareaTurno_TimeSpan_PrefijaDescripcion()
    {
        var cuidador = new CuidadorResidencia("Luis", "Mañana", 3);
        cuidador.AñadeTareaTurno(new TimeSpan(7, 0, 0), "Aseo");

        AssertSalidaGestionaTurnoExacta(cuidador, new TimeSpan(7, 0, 0), "Cuidador: Aseo");
        AssertToStringContieneTarea(cuidador, new TimeSpan(7, 0, 0), "Cuidador: Aseo");
    }

    [Fact(DisplayName = "Cuidador: AñadeTareaTurno(TareaTurno) prefija descripción")]
    public void Cuidador_AnadeTareaTurno_TareaTurno_PrefijaDescripcion()
    {
        var cuidador = new CuidadorResidencia("Luis", "Mañana", 3);
        cuidador.AñadeTareaTurno(new TareaTurno(new TimeSpan(12, 0, 0), "Comida"));

        AssertSalidaGestionaTurnoExacta(cuidador, new TimeSpan(12, 0, 0), "Cuidador: Comida");
        AssertToStringContieneTarea(cuidador, new TimeSpan(12, 0, 0), "Cuidador: Comida");
    }

    [Fact(DisplayName = "Enfermero asigna y recupera tareas exactas")]
    public void DebeDevolverTareaExacta()
    {
        var enfermero = new Enfermero("Ana", "Noche", 10);
        enfermero.AñadeTareaTurno(new TimeSpan(8,0,0), "Entrega de turno");
        string resultado = enfermero.GestionaTurno(new DateTime(2025,9,1,8,0,0));
        Assert.Contains("Entrega de turno", resultado);
    }

    [Fact(DisplayName = "Cuando no hay tarea exacta devuelve la anterior más cercana")]
    public void DebeDevolverAnteriorMasCercana()
    {
        var cuidador = new CuidadorResidencia("Luis", "Mañana", 3);
        cuidador.AñadeTareaTurno(new TimeSpan(7,0,0), "Aseo");
        cuidador.AñadeTareaTurno(new TimeSpan(9,0,0), "Desayuno");
        string resultado = cuidador.GestionaTurno(new DateTime(2025,9,1,8,30,0));
        Assert.Contains("07:00", resultado);
        Assert.Contains("Aseo", resultado);
    }

    [Fact(DisplayName = "Si no hay ninguna tarea previa ni exacta avisa sin tarea")]
    public void DebeAvisarSinTarea()
    {
        var enfermero = new Enfermero("Ana", "Noche", 10);
        string resultado = enfermero.GestionaTurno(new DateTime(2025,9,1,6,0,0));
        Assert.Contains("No hay tarea", resultado);
    }

    [Fact(DisplayName = "GestionaPersonal imprime listado y gestiones de turno")]
    public void GestionaPersonal_MuestraInformacion()
    {
        using var sw = new StringWriter();
        var original = Console.Out;
        Console.SetOut(sw);
        Program.GestionaPersonal();
        Console.SetOut(original);
        var salida = sw.ToString();
        Assert.Contains("Ejercicio 1: Gestión de personal de cuidados", salida);
        Assert.Contains("Ana Ruiz", salida);
        Assert.Contains("Luis Pérez", salida);
        Assert.Contains("Gestión de turno a las 23:00", salida);
        Assert.Contains("Gestión de turno a las 15:00", salida);
    }
}
