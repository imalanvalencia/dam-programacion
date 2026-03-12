using Xunit;
using Ejercicio3;
using System;
using System.IO;

namespace ejercicio3.tests;

public class UnitTest1
{
    [Fact]
    public void Mostrar_ImprimeMatrizCorrectamente()
    {
        // Arrange
        int[][] matriz = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Principal.Mostrar(matriz);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("1", output);
        Assert.Contains("2", output);
        Assert.Contains("3", output);
        Assert.Contains("4", output);
    }

    
}
