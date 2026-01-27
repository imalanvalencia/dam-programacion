
using Ejercicio4;

namespace ejercicio4.tests;

public class HerramientasAvanzadasTests
{
    [Fact]
    public void SierraElectrica_PrecioConRecargo()
    {
        var sierra = new SierraElectrica("Sierra Circular", "Makita", 4.1, 120, 1400, 185);
        Assert.Equal(132, sierra.Precio);
    }

    [Fact]
    public void Lijadora_DescuentoEcologico()
    {
        var lijadora = new Lijadora("Lijadora Orbital", "Dewalt", 1.8, 54, 9000, 125);
        Assert.Equal(48.6, lijadora.Precio, 1);
    }

    [Fact]
    public void Taladro_Perforar_DevuelveCadenaCorrecta()
    {
        var taladro = new Taladro("Taladro Percutor", "Bosch", 2.3, 100, 750, 3000);
        var resultado = taladro.Perfora(8, 60);
        Assert.Contains("8mm", resultado);
        Assert.Contains("60mm", resultado);
    }

    [Fact]
    public void Lijadora_Pule_CalculaTiempo()
    {
        var lijadora = new Lijadora("Lijadora Orbital", "Dewalt", 1.8, 54, 9000, 125);
        double tiempo = lijadora.Pule(2.5);
        Assert.True(tiempo > 0);
    }

    [Fact]
    public void GestionHerramientasPolimorfismo_ImprimeSalidaCorrectaYCompleta()
    {
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Ejercicio4.Program.GestionHerramientasPolimorfismo();
        Console.SetOut(originalOut);
        var output = sw.ToString();
        // Herramientas y precios
        Assert.Contains("Martillo", output);
        Assert.Contains("Taladro Percutor", output);
        Assert.Contains("Sierra Circular", output);
        Assert.Contains("Lijadora Orbital", output);
        Assert.Contains("25", output); // Martillo
        Assert.Contains("89,25", output); // Taladro
        Assert.Contains("132", output); // Sierra
        Assert.Contains("48,6", output); // Lijadora
        // Descripciones
        Assert.Contains("Potencia: 750", output);
        Assert.Contains("Hoja: 185mm", output);
        Assert.Contains("RPM: 9000", output);
        // Usos

        Assert.Contains("Perfora materiales duros", output);
        Assert.Contains("Realiza cortes rectos", output);
        Assert.Contains("Lija y suaviza superficies", output);
        // Métodos específicos
        Assert.Contains("Pulir(2.5 m2)", output);
        Assert.Contains("Cortar(\"Madera\", 18mm)", output);
        Assert.Contains("Perforar 8mm diámetro, 60mm profundidad", output);
        // Secciones
        Assert.Contains("Mostrando usos", output);
        Assert.Contains("Accediendo a métodos específicos", output);
    }
}
