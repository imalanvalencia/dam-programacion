using System;
using System.IO;
using Xunit;

namespace ejercicio7.test;

public class UnitTest1
{
    [Fact]
    public void LeeTemperaturas_DeberiaGenerar7Temperaturas()
    {
        // Act
        double[] resultado = Program.LeeTemperaturas();

        // Assert
        Assert.Equal(7, resultado.Length);
        foreach (double temp in resultado)
        {
            Assert.True(temp >= 4 && temp <= 35, $"La temperatura {temp} no está en el rango 4-35");
        }
    }

    [Fact]
    public void CalculaMedia_DeberiaCalcularMediaCorrectamente()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };

        // Act
        double resultado = Program.CalculaMedia(temperaturas);

        // Assert
        double expectedMedia = (22.5 + 18.3 + 25.1 + 19.8 + 23.4 + 27.2 + 21.6) / 7;
        Assert.Equal(expectedMedia, resultado, 1);
    }

    [Fact]
    public void BuscaMaximo_DeberiaRetornarMaximoYPosicion()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };

        // Act
        var (temperatura, dia) = Program.BuscaMaximo(temperaturas);

        // Assert
        Assert.Equal(27.2, temperatura, 1);
        Assert.Equal(5, dia); // Sábado (índice 5)
    }

    [Fact]
    public void BuscaMinimo_DeberiaRetornarMinimoYPosicion()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };

        // Act
        var (temperatura, dia) = Program.BuscaMinimo(temperaturas);

        // Assert
        Assert.Equal(18.3, temperatura, 1);
        Assert.Equal(1, dia); // Martes (índice 1)
    }

    [Fact]
    public void CuentaDiasSuperioresA_DeberiaContarCorrectamente()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };
        double umbral = 22.0;

        // Act
        int resultado = Program.CuentaDiasSuperioresA(temperaturas, umbral);

        // Assert
        Assert.Equal(4, resultado); // 22.5, 25.1, 23.4, 27.2
    }

    [Fact]
    public void TemperaturasAltas_DeberiaRetornarSoloTemperaturasSuperioresA25()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };

        // Act
        double[] resultado = Program.TemperaturasAltas(temperaturas);

        // Assert
        Assert.Equal(2, resultado.Length);
        Assert.Equal(25.1, resultado[0], 1);
        Assert.Equal(27.2, resultado[1], 1);
    }

    [Fact]
    public void TemperaturasAltas_ConNingunaTemperaturaAlta_DeberiaRetornarArrayVacio()
    {
        // Arrange
        double[] temperaturas = { 22.5, 18.3, 20.1, 19.8, 23.4, 24.2, 21.6 };

        // Act
        double[] resultado = Program.TemperaturasAltas(temperaturas);

        // Assert
        Assert.Empty(resultado);
    }

    [Fact]
    public void MuestraTemperaturas_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] temperaturas = { 22.5, 18.3, 25.1, 19.8, 23.4, 27.2, 21.6 };

        // Act
        Program.MuestraTemperaturas(temperaturas);

        // Assert
        var result = output.ToString();

        // Verificar que aparece el título
        Assert.Contains("Temperaturas de la semana:", result);

        // Verificar que aparecen todos los días con sus temperaturas
        Assert.Contains("Lunes: 22,5°C", result);
        Assert.Contains("Martes: 18,3°C", result);
        Assert.Contains("Miércoles: 25,1°C", result);
        Assert.Contains("Jueves: 19,8°C", result);
        Assert.Contains("Viernes: 23,4°C", result);
        Assert.Contains("Sábado: 27,2°C", result);
        Assert.Contains("Domingo: 21,6°C", result);
    }

    [Fact]
    public void MuestraTemperaturas_ConTemperaturasExtremas_DeberiaFormatearCorrectamente()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] temperaturas = { 4.0, 35.0, 0.5, 100.7, 15.25, 30.99, 8.1 };

        // Act
        Program.MuestraTemperaturas(temperaturas);

        // Assert
        var result = output.ToString();

        // Verificar formato con un decimal
        Assert.Contains("Lunes: 4,0°C", result);
        Assert.Contains("Martes: 35,0°C", result);
        Assert.Contains("Miércoles: 0,5°C", result);
        Assert.Contains("Jueves: 100,7°C", result);
        Assert.Contains("Viernes: 15,3°C", result); // 15.25 redondeado a 15,3
        Assert.Contains("Sábado: 31,0°C", result);   // 30.99 redondeado a 31,0
        Assert.Contains("Domingo: 8,1°C", result);
    }

    [Fact]
    public void MuestraTemperaturas_ConArrayVacio_NoDeberiaFallar()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] temperaturas = { };

        // Act & Assert - No debería lanzar excepción
        Program.MuestraTemperaturas(temperaturas);

        var result = output.ToString();
        Assert.Contains("Temperaturas de la semana:", result);
    }
}
