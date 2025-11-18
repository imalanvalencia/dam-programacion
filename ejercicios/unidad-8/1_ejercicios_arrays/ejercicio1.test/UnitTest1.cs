using System;
using System.IO;
using Xunit;

namespace ejercicio1.test;

public class UnitTest1
{
    [Fact]
    public void GeneraNumerosAleatorios_DeberiaGenerar10Numeros()
    {
        // Act
        double[] resultado = Program.GeneraNumerosAleatorios();

        // Assert
        Assert.Equal(10, resultado.Length);
        foreach (double numero in resultado)
        {
            Assert.True(numero >= 0 && numero < 100, $"El número {numero} no está en el rango 0-100");
        }
    }

    [Fact]
    public void MuestraArrayCompleto_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        double[] array = { 45.67, 23.89, 78.45 };

        try
        {
            // Act
            Program.MuestraArrayCompleto(array);

            // Assert
            var result = output.ToString();
            Assert.Contains("Array completo:", result);
            Assert.Contains("[0]: 45,67", result);
            Assert.Contains("[1]: 23,89", result);
            Assert.Contains("[2]: 78,45", result);
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Fact]
    public void MuestraMultiplosDe4_DeberiaMotrarSoloMultiplosDe4()
    {
        // Arrange
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        double[] array = { 10.5, 20.3, 30.1, 40.7, 50.2, 60.8, 70.4, 80.9, 90.1, 100.6 };

        try
        {
            // Act
            Program.MuestraMultiplosDe4(array);

            // Assert
            var result = output.ToString();
            Assert.Contains("Números en posiciones múltiplo de 4:", result);
            Assert.Contains("Posición [0]: 10,50", result);
            Assert.Contains("Posición [4]: 50,20", result);
            Assert.Contains("Posición [8]: 90,10", result);

            // No debería mostrar otras posiciones
            Assert.DoesNotContain("Posición [1]:", result);
            Assert.DoesNotContain("Posición [2]:", result);
            Assert.DoesNotContain("Posición [3]:", result);
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Fact]
    public void MuestraMultiplosDe4_ConArrayVacio_NoDeberiafallar()
    {
        // Arrange
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        double[] array = { };

        try
        {
            // Act & Assert
            Program.MuestraMultiplosDe4(array); // No debería lanzar excepción
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }
}
