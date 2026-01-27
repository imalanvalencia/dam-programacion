
using Ejercicio1;

namespace ejercicio1.tests;

public class HerramientaTests
{
    [Fact]
    public void Martillo_PropiedadesCorrectas()
    {
        var martillo = new Herramienta("Martillo", "Stanley", 0.5, 25);
        Assert.Equal("Martillo", martillo.Nombre);
        Assert.Equal("Stanley", martillo.Marca);
        Assert.Equal(0.5, martillo.Peso);
        Assert.Equal(25, martillo.Precio);
    }

    [Fact]
    public void Taladro_PrecioConDescuento()
    {
        var taladro = new Taladro("Taladro Percutor", "Bosch", 2.3, 100, 750, 3000);
        Assert.Equal(85, taladro.Precio);
    }

    [Fact]
    public void Taladro_PropiedadesEspecificas()
    {
        var taladro = new Taladro("Taladro Percutor", "Bosch", 2.3, 100, 750, 3000);
        Assert.Equal(750, taladro.Potencia);
        Assert.Equal(3000, taladro.VelocidadMaxima);
    }


    [Fact]
    public void GestionHerramientas_ImprimeSalidaCorrecta()
    {
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Program.GestionHerramientas();
        Console.SetOut(originalOut);
        var output = sw.ToString();
        Assert.Contains("Martillo, Marca: Stanley, Peso: 0,5, Precio: 25", output);
        Assert.Contains("Taladro Percutor, Marca: Bosch, Peso: 2,3, Precio: 89,25, Potencia: 750, Velocidad Máxima: 3000", output);
    }
}
