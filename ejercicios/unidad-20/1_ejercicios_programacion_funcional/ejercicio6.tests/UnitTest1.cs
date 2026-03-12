using Xunit;
using Ejercicio6;
using System;
using System.IO;

namespace ejercicio6.tests;

public class UnitTest1
{
    [Fact]
    public void ObtenTemperaturaMaxima_RetornaMaxima()
    {
        var txp = new Program.TemperaturasXProvincia("Test", 30, 10);
        Assert.Equal(30, Program.ObtenTemperaturaMaxima(txp));
    }

    [Fact]
    public void ObtenTemperaturaMinima_RetornaMinima()
    {
        var txp = new Program.TemperaturasXProvincia("Test", 30, 10);
        Assert.Equal(10, Program.ObtenTemperaturaMinima(txp));
    }

    [Fact]
    public void MayorQue_RetornaTrueSiMayor()
    {
        Assert.True(Program.MayorQue(10, 5));
        Assert.False(Program.MayorQue(5, 10));
    }

    [Fact]
    public void MenorQue_RetornaTrueSiMenor()
    {
        Assert.True(Program.MenorQue(5, 10));
        Assert.False(Program.MenorQue(10, 5));
    }

    [Fact]
    public void IgualQue_RetornaTrueSiIgual()
    {
        Assert.True(Program.IgualQue(5, 5));
        Assert.False(Program.IgualQue(5, 10));
    }

    [Fact]
    public void MediaTemperaturas_CalculaMediaCorrectamente()
    {
        var datos = new Program.TemperaturasXProvincia[]
        {
            new Program.TemperaturasXProvincia("P1", 20, 10),
            new Program.TemperaturasXProvincia("P2", 30, 20)
        };

        float media = Program.MediaTemperaturas(datos, Program.ObtenTemperaturaMaxima);
        Assert.Equal(25, media);
    }

    [Fact]
    public void MuestraProvincias_ImprimeProvinciasCorrectas()
    {
        // Arrange
        var datos = new Program.TemperaturasXProvincia[]
        {
            new Program.TemperaturasXProvincia("P1", 20, 10), // Max 20
            new Program.TemperaturasXProvincia("P2", 30, 20)  // Max 30
        };
        float media = 25;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Program.MuestraProvincias(datos, media, Program.ObtenTemperaturaMaxima, Program.MayorQue);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("P2", output);
        Assert.DoesNotContain("P1", output);
    }
}
