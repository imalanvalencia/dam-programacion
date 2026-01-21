

namespace ejercicio6.tests;

using System;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void Circulo_CalculaAreaYPerimetroCorrectamente()
    {
        // Arrange
        float radio = 5.0f;
        var circulo = new Circulo(radio);

        // Act
        var area = circulo.Area();
        var perimetro = circulo.Perimetro();

        // Assert
        Assert.Equal((float)(Math.PI * Math.Pow(radio, 2)), area, 2);
        Assert.Equal((float)(2 * Math.PI * radio), perimetro, 2);
    }

    [Fact]
    public void Pincel_AsignaColorCorrectamente()
    {
        // Arrange
        var pincel = new Pincel();

        // Act
        pincel.Color = Color.Rojo;

        // Assert
        Assert.Equal(Color.Rojo, pincel.Color);
    }

    [Fact]
    public void Rotulador_ConstructorAsignaColorCorrecto()
    {
        // Arrange
        string colorStr = "Azul";

        // Act
        var rotulador = new Rotulador(colorStr);

        // Assert
        Assert.Equal(Color.Azul, rotulador.Color);
    }

    [Fact]
    public void Rotulador_ObtenerColorRetornaColor()
    {
        // Arrange
        var rotulador = new Rotulador("Verde");

        // Act
        var color = rotulador.Color;

        // Assert
        Assert.Equal(Color.Verde, color);
    }

    [Fact]
    public void Estuche_GetRotuladoresRetorna5Rotuladores()
    {
        // Act
        var rotuladores = Estuche.GetRotuladores();

        // Assert
        Assert.Equal(Estuche.NUMERO_ROTULADORES, rotuladores.Length);
        Assert.All(rotuladores, r => Assert.NotNull(r));
    }

    [Fact]
    public void Compas_DibujaCirculoRetornaCirculoConRadioCorrecto()
    {
        // Arrange
        var compas = new Compas();
        float radio = 10.0f;

        // Act
        var circulo = compas.DibujaCirculo(radio);

        // Assert
        Assert.NotNull(circulo);
        Assert.Equal(radio, circulo.Radio);
    }
}
