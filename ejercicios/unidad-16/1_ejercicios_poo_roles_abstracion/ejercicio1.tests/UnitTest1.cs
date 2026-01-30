using System;
using System.Linq;

namespace ejercicio1.tests;

public class TestsPersonalCuidados
{
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
