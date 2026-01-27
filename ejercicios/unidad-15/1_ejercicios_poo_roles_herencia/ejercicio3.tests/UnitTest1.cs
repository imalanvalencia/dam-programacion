
using Ejercicio3;
using System.Collections.Generic;

namespace ejercicio3.tests;

public class PersonajeTests
{
    [Fact]
    public void Guerrero_Ataca_FormatoYCalculoActual()
    {
        var habilidades = new List<Habilidad> { new Habilidad("Furia", 50), new Habilidad("Golpe", 30) };
        var guerrero = new Guerrero("Conan", 100, habilidades, 20);
        var resultado = guerrero.Ataca();
        // El método suma todos los daños y hace fuerza + (totalDaño / 2)
        // 50 + 30 = 80; 80/2 = 40; 20 + 40 = 60
        Assert.Contains("Conan ataca con Furia", resultado);
        Assert.Contains("60", resultado);
        Assert.Contains("fuerza 20", resultado);
    }

    [Fact]
    public void Mago_Ataca_FormatoYCalculoActual()
    {
        var habilidades = new List<Habilidad> { new Habilidad("Bola de Fuego", 70), new Habilidad("Rayo", 40) };
        var mago = new Mago("Gandalf", 120, habilidades, 50);
        var resultado = mago.Ataca();
        // El método suma todos los daños y hace maná + totalDaño
        // 70 + 40 = 110; 110 + 50 = 160
        Assert.Contains("Gandalf ataca con Bola de Fuego", resultado);
        Assert.Contains("160", resultado);
        Assert.Contains("maná 50", resultado);
    }

    [Fact]
    public void Personaje_SinHabilidades_UsaPorDefecto()
    {
        var personaje = new Guerrero("SinHabilidad", 50, new List<Habilidad>(), 10);
        Assert.Contains("No Hábil", personaje.ACadena());
    }

    [Fact]
    public void AñadirHabilidad_IncrementaLista()
    {
        var mago = new Mago("Merlín", 100, new List<Habilidad>(), 30);
        int antes = mago.Habilidades.Count;
        mago.AñadeHabilidad(new Habilidad("Nueva", 10));
        Assert.Equal(antes + 1, mago.Habilidades.Count);
    }

    [Fact]
    public void GestionPersonajes_ImprimeSalidaCorrecta()
    {
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Ejercicio3.Program.GestionPersonajes();
        Console.SetOut(originalOut);
        var output = sw.ToString();
        Assert.Contains("Guerrero creado:", output);
        Assert.Contains("Mago creado:", output);
        Assert.Contains("Furia", output);
        Assert.Contains("Bola de Fuego", output);
        Assert.Contains("Acciones de los personajes", output);
    }
}
