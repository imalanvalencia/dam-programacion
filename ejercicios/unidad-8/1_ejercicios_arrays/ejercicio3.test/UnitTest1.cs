using System;
using System.IO;
using Xunit;

namespace ejercicio3.test;

public class UnitTest1
{
    [Fact]
    public void GeneraArrayAleatorio_DeberiaGenerar10Elementos()
    {
        // Act
        int[] resultado = Program.GeneraArrayAleatorio();

        // Assert
        Assert.Equal(10, resultado.Length);
        foreach (int numero in resultado)
        {
            Assert.True(numero >= 1 && numero <= 100, $"El número {numero} no está en el rango 1-100");
        }
    }

    [Fact]
    public void EncuentraMayor_DeberiaRetornarElMayor()
    {
        // Arrange
        int[] array = { 45, 23, 78, 12, 89, 56, 34, 67, 91, 43 };

        // Act
        int resultado = Program.EncuentraMayor(array);

        // Assert
        Assert.Equal(91, resultado);
    }

    [Fact]
    public void EncuentraMayor_ConUnSoloElemento_DeberiaRetornarEseElemento()
    {
        // Arrange
        int[] array = { 42 };

        // Act
        int resultado = Program.EncuentraMayor(array);

        // Assert
        Assert.Equal(42, resultado);
    }

    [Fact]
    public void EncuentraPosicionMayor_DeberiaRetornarLaPrimeraPosicion()
    {
        // Arrange
        int[] array = { 45, 23, 78, 12, 89, 56, 34, 67, 91, 43 };

        // Act
        int resultado = Program.EncuentraPosicionMayor(array);

        // Assert
        Assert.Equal(8, resultado); // El 91 está en la posición 8
    }

    [Fact]
    public void EncuentraPosicionMayor_ConElementosIguales_DeberiaRetornarLaPrimera()
    {
        // Arrange
        int[] array = { 10, 20, 30, 30, 20, 10 };

        // Act
        int resultado = Program.EncuentraPosicionMayor(array);

        // Assert
        Assert.Equal(2, resultado); // El primer 30 está en la posición 2
    }

    [Fact]
    public void MuestraArray_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        int[] array = { 1, 2, 3 };

        // Act
        Program.MuestraArray(array);

        // Assert
        var result = output.ToString();
        Assert.Contains("Array: [1, 2, 3]", result);
    }
}
