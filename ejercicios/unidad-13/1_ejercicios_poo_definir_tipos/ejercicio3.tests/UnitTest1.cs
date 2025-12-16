using System;
using System.IO;

namespace ejercicio3.tests;

public class CirculoTests
{
    [Fact]
    public void Constructor_DeberiaAsignarRadio()
    {
        // Arrange & Act
        var circulo = new Circulo(5.0f);
        
        // Assert - Como GetRadio es privado, probamos a través de los métodos públicos
        Assert.Equal(Math.PI * 25, circulo.Area(), 5); // π * r²
        Assert.Equal(2 * Math.PI * 5, circulo.Perimetro(), 5); // 2π * r
    }

    [Fact]
    public void Area_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var circulo = new Circulo(3.0f);
        var areaEsperada = Math.PI * 9; // π * 3²
        
        // Act
        var area = circulo.Area();
        
        // Assert
        Assert.Equal(areaEsperada, area, 5);
    }

    [Fact]
    public void Perimetro_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var circulo = new Circulo(4.0f);
        var perimetroEsperado = 2 * Math.PI * 4; // 2π * 4
        
        // Act
        var perimetro = circulo.Perimetro();
        
        // Assert
        Assert.Equal(perimetroEsperado, perimetro, 5);
    }
}

public class PincelTests
{
    [Fact]
    public void SetColor_DeberiaEstablecerColor()
    {
        // Arrange
        var pincel = new Pincel();
        
        // Act
        pincel.SetColor(Color.Rojo);
        
        // Assert - Verificamos a través del método Pinta que usa el color
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            pincel.Pinta(10.5f);
            var output = sw.ToString();
            Assert.Contains("Rojo", output);
        }
    }

    [Fact]
    public void Pinta_DeberiaGenerarMensajeCorreecto()
    {
        // Arrange
        var pincel = new Pincel();
        pincel.SetColor(Color.Verde);
        
        // Act & Assert
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            pincel.Pinta(25.75f);
            var output = sw.ToString();
            
            Assert.Contains("Pintada el área de 25,75 cm² de color Verde", output);
        }
    }
}

public class RotuladorTests
{
    [Fact]
    public void Constructor_ConColorValido_DeberiaCrearRotulador()
    {
        // Arrange & Act
        var rotulador = new Rotulador("Azul");
        
        // Assert
        Assert.Equal(Color.Azul, rotulador.ObtenerColor());
    }

    [Fact]
    public void Constructor_ConColorInvalido_DeberiaLanzarExcepcion()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rotulador("ColorInexistente"));
    }

    [Fact]
    public void Rotula_DeberiaGenerarMensajeCorreecto()
    {
        // Arrange
        var rotulador = new Rotulador("Negro");
        
        // Act & Assert
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            rotulador.Rotula(15.25f);
            var output = sw.ToString();
            
            Assert.Contains("Rotulado el perímetro de 15,25 cm de color Negro", output);
        }
    }

    [Fact]
    public void ObtenerColor_DeberiaRetornarColorCorreecto()
    {
        // Arrange
        var rotulador = new Rotulador("Verde");
        
        // Act
        var color = rotulador.ObtenerColor();
        
        // Assert
        Assert.Equal(Color.Verde, color);
    }
}

public class EstucheTests
{
    [Fact]
    public void NUMERO_ROTULADORES_DeberiaSerCinco()
    {
        // Assert
        Assert.Equal(5, Estuche.NUMERO_ROTULADORES);
    }

    [Fact]
    public void GetRotuladores_DeberiaRetornarArrayConColoresCorrectos()
    {
        // Act
        var rotuladores = Estuche.GetRotuladores();
        
        // Assert
        Assert.Equal(5, rotuladores.Length);
        Assert.Equal(Color.Rojo, rotuladores[0].ObtenerColor());
        Assert.Equal(Color.Azul, rotuladores[1].ObtenerColor());
        Assert.Equal(Color.Verde, rotuladores[2].ObtenerColor());
        Assert.Equal(Color.Amarillo, rotuladores[3].ObtenerColor());
        Assert.Equal(Color.Negro, rotuladores[4].ObtenerColor());
    }

    [Fact]
    public void GetRotuladores_DeberiaRetornarNuevoArrayCadaVez()
    {
        // Act
        var rotuladores1 = Estuche.GetRotuladores();
        var rotuladores2 = Estuche.GetRotuladores();
        
        // Assert
        Assert.NotSame(rotuladores1, rotuladores2); // Referencias diferentes
        Assert.Equal(rotuladores1.Length, rotuladores2.Length); // Pero mismo contenido
    }
}

public class CompasTests
{
    [Fact]
    public void DibujaCirculo_DeberiaCrearCirculoConRadioCorrecto()
    {
        // Arrange
        var compas = new Compas();
        
        // Act
        var circulo = compas.DibujaCirculo(7.5f);
        
        // Assert
        var areaEsperada = Math.PI * 7.5f * 7.5f;
        Assert.Equal(areaEsperada, circulo.Area(), 3);
    }

    [Fact]
    public void DibujaCirculo_DeberiaGenerarMensajeCorreecto()
    {
        // Arrange
        var compas = new Compas();
        
        // Act & Assert
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            compas.DibujaCirculo(3.5f);
            var output = sw.ToString();
            
            Assert.Contains("Dibujado un círculo de radio 3,5 cm", output);
        }
    }
}
