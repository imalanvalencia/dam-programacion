using System;
using System.IO;
using Xunit;

namespace ejercicio10.test;

public class UnitTest1
{
    [Fact]
    public void LeeVector_DeberiaLeerComponentesCorrectamente()
    {
        // Arrange
        var input = "1,5\n2,3\n-0,8\n";
        Console.SetIn(new StringReader(input));

        // Act
        double[] resultado = Program.LeeVector("A", 3);

        // Assert
        Assert.Equal(3, resultado.Length);
        Assert.Equal(1.5, resultado[0], 1);
        Assert.Equal(2.3, resultado[1], 1);
        Assert.Equal(-0.8, resultado[2], 1);
    }

    [Fact]
    public void SumaVectores_DeberiasumarCorrectamente()
    {
        // Arrange
        double[] vectorA = { 1.5, 2.3, -0.8, 3.2 };
        double[] vectorB = { 2.1, -1.4, 4.5, 0.7 };

        // Act
        double[] resultado = Program.SumaVectores(vectorA, vectorB);

        // Assert
        Assert.Equal(4, resultado.Length);
        Assert.Equal(3.6, resultado[0], 1);
        Assert.Equal(0.9, resultado[1], 1);
        Assert.Equal(3.7, resultado[2], 1);
        Assert.Equal(3.9, resultado[3], 1);
    }

    [Fact]
    public void RestaVectores_DeberiaRestarCorrectamente()
    {
        // Arrange
        double[] vectorA = { 1.5, 2.3, -0.8, 3.2 };
        double[] vectorB = { 2.1, -1.4, 4.5, 0.7 };

        // Act
        double[] resultado = Program.RestaVectores(vectorA, vectorB);

        // Assert
        Assert.Equal(4, resultado.Length);
        Assert.Equal(-0.6, resultado[0], 1);
        Assert.Equal(3.7, resultado[1], 1);
        Assert.Equal(-5.3, resultado[2], 1);
        Assert.Equal(2.5, resultado[3], 1);
    }

    [Fact]
    public void ProductoEscalar_DeberiaCalcularCorrectamente()
    {
        // Arrange
        double[] vectorA = { 1.0, 2.0, 3.0 };
        double[] vectorB = { 4.0, 5.0, 6.0 };

        // Act
        double resultado = Program.ProductoEscalar(vectorA, vectorB);

        // Assert
        Assert.Equal(32.0, resultado, 1); // 1*4 + 2*5 + 3*6 = 4 + 10 + 18 = 32
    }

    [Fact]
    public void CalculaMagnitud_DeberiaCalcularCorrectamente()
    {
        // Arrange
        double[] vector = { 3.0, 4.0 }; // Vector (3,4) tiene magnitud 5

        // Act
        double resultado = Program.CalculaMagnitud(vector);

        // Assert
        Assert.Equal(5.0, resultado, 1);
    }





    [Fact]
    public void MuestraVector_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] vector = { 1.5, 2.3, -0.8 };

        // Act
        Program.MuestraVector(vector, "A");

        // Assert
        var result = output.ToString();
        Assert.Contains("Vector A: [1,50, 2,30, -0,80]", result);
    }
}
