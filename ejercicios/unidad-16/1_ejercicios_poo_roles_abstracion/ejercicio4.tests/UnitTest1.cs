using System;

namespace ejercicio4.tests;

public class TestsEntrenamiento
{
    [Fact(DisplayName = "Calorías sentadillas peso mayores que básicas")]
    public void CaloriasSentadillas()
    {
        var sBasica = new Sentadillas(Sentadillas.TipoSentadillas.Basica, 6, DateTime.Today) { DuracionMinutos = 20 };
        var sPeso = new Sentadillas(Sentadillas.TipoSentadillas.Peso, 8, DateTime.Today) { DuracionMinutos = 25 };
        Assert.True(sPeso.CaloriasEstimadas > sBasica.CaloriasEstimadas);
    }

    [Fact(DisplayName = "Running calcula calorías base + distancia")]
    public void CaloriasRunning()
    {
        var r = new Running(7.5, 4, DateTime.Today) { DuracionMinutos = 45 };
        double esperado = 45 * 4 * 1.2 + 7.5 * 10;
        Assert.Equal(esperado, r.CaloriasEstimadas, 3);
    }

    [Fact(DisplayName = "GestionarEntrenamiento imprime comparativa")]
    public void GestionarEntrenamiento_MuestraInformacion()
    {
        using var sw = new StringWriter();
        var original = Console.Out;
        Console.SetOut(sw);
        Program.GestionarEntrenamiento();
        Console.SetOut(original);
        var salida = sw.ToString();
        Assert.Contains("Ejercicio 4: Interfaces y entrenamiento", salida);
        Assert.Contains("Running", salida);
        Assert.Contains("Sentadillas", salida);
        Assert.Contains("Calorías", salida);
    }
}
