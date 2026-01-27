
using Ejercicio2;

namespace ejercicio2.tests;

public class CineTests
{
    [Fact]
    public void Local_DimensionesCorrectas()
    {
        var local = new Local("Alicante", "Calle Falsa", "2", 10, 20);
        Assert.Equal("Alicante", local.Ciudad);
        Assert.Equal("Calle Falsa", local.Calle);
        Assert.Equal("2", local.NumeroPlantas);
        Assert.Equal(200, local.Dimensiones.Ancho * local.Dimensiones.Largo);
    }

    [Fact]
    public void LocalComercial_PropiedadesAdicionales()
    {
        var lc = new LocalComercial("Alicante", "Calle Falsa", "2", 10, 20, "Comercio", "123");
        Assert.Equal("Comercio", lc.RazonSocial);
        Assert.Equal("123", lc.NumeroLicencia);
    }

    [Fact]
    public void Cine_AforoCorrecto()
    {
        var cine = new Cine("Alicante", "Calle Falsa", "2", 10, 20, "Cinesa", "123", 150);
        Assert.Equal(150, cine.AforoSala);
    }


    [Fact]
    public void GestionCines_ImprimeSalidaCorrecta()
    {
        using var sw = new System.IO.StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(sw);
        Ejercicio2.Program.GestionCines();
        Console.SetOut(originalOut);
        var output = sw.ToString();
        Assert.Contains("Local:", output);
        Assert.Contains("Cine:", output);
        Assert.Contains("Aforo de la sala: 200 personas", output);
        Assert.Contains("Aforo de la sala: 350 personas", output);
        Assert.Contains("Aforo de la sala: 450 personas", output);
    }
}
