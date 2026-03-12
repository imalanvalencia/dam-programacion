using Xunit;
using Ejercicio5;
using System;
using System.IO;

namespace ejercicio5.tests;

public class UnitTest1
{
    [Fact]
    public void Suma_RetornaSuma()
    {
        Assert.Equal(15, Principal.Suma(7, 8));
    }

    [Fact]
    public void CuadradoDe_RetornaCuadrado()
    {
        Assert.Equal(64, Principal.CuadradoDe(8));
    }

    [Fact]
    public void GetVelocidadParada_RetornaValor()
    {
        Assert.Equal(108.4, Principal.GetVelocidadParada());
    }

    [Fact]
    public void EsMultiploDeCinco_RetornaTrueSiMultiplo()
    {
        Assert.True(Principal.EsMultiploDeCinco(10));
        Assert.False(Principal.EsMultiploDeCinco(7));
    }

    [Fact]
    public void Calcula_RetornaResultadoCorrecto()
    {
        // Arrange
        var input = "2\n3"; // var1=2, var2=3
        var stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        double resultado = Principal.Calcula("Potencia", "v1", "v2");

        // Assert
        Assert.Equal(6, resultado);
    }

   /*  [Fact]
    public void ProcedimientoDesconocido_ImprimeCorrectamente()
    {
        // Arrange
        double[,] x = { { 1, 2 }, { 3, 4 } };
        int[] y = { 1, 1, 1, 1 }; // Flattened length matches x
        string z = "Prefix: ";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Principal.ProcedimientoDesconocido(x, y, z);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Prefix:", output);
    } */
}
