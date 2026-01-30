using System;

namespace ejercicio5.tests;

public class TestsMedia
{
    private Disc CrearDiscoDemo()
    {
        return new Disc("Demo", "Artista", new[]{"Tema1","Tema2","Tema3"});
    }

    [Fact(DisplayName = "Inicio en modo DAB sin CD (no se comprueba NO DISC)")]
    public void CdPlayerSinDisco()
    {
        var sistema = new DABRadioCD();
        Assert.Contains("MODO: DAB", sistema.MessageToDisplay);
        Assert.Contains("RADIO OFF", sistema.MessageToDisplay); // Estado inicial de la radio
    }

    [Fact(DisplayName = "Cambiar a modo CD sin disco muestra NO DISC")]
    public void CambiarModoSinDisco()
    {
        var sistema = new DABRadioCD();
        sistema.SwitchMode(); // pasa a CD sin disco
        Assert.Contains("MODO: CD", sistema.MessageToDisplay);
        Assert.Contains("NO DISC", sistema.MessageToDisplay);
    }

    [Fact(DisplayName = "Insertar CD cambia a modo CD y reproduce")]
    public void InsertarCDReproduce()
    {
        var sistema = new DABRadioCD();
        sistema.InsertCD = CrearDiscoDemo();
        Assert.Contains("MODO: CD", sistema.MessageToDisplay);
        Assert.Contains("PLAYING", sistema.MessageToDisplay);
    }

    [Fact(DisplayName = "Extraer CD vuelve a modo DAB")]
    public void ExtraerCDModoDab()
    {
        var sistema = new DABRadioCD();
        sistema.InsertCD = CrearDiscoDemo();
        sistema.ExtractCD();
        Assert.Contains("MODO: DAB", sistema.MessageToDisplay);
    }

    [Fact(DisplayName = "MostrarInterfazInicial imprime cabecera y estado inicial")]
    public void MostrarInterfazInicial_MuestraCabecera()
    {
        using var sw = new StringWriter();
        var original = Console.Out;
        Console.SetOut(sw);
        Program.MostrarInterfazInicial();
        Console.SetOut(original);
        var salida = sw.ToString();
        Assert.Contains("Ejercicio 5", salida);
        Assert.Contains("Sistema Multimedia", salida);
        Assert.Contains("MODO: DAB", salida);
    }
}
