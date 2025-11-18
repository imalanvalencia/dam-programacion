using System;
using System.IO;
using Xunit;

namespace ejercicio2.test;

public class UnitTest1
{
    [Fact]
    public void GenerarCaracteresAleatorios_DeberiaGenerar10Caracteres()
    {
        // Act
        char[] resultado = Program.GeneraCaracteresAleatorios();

        // Assert
        Assert.Equal(10, resultado.Length);
        foreach (char c in resultado)
        {
            Assert.True(char.IsLetter(c), $"El carácter '{c}' no es una letra");
        }
    }

    [Fact]
    public void ConvierteMayusculasMinusculas_DeberiaConvertirCorrectamente()
    {
        // Arrange
        char[] caracteres = { 'A', 'b', 'C', 'd', 'E' };
        char[] esperado = { 'a', 'B', 'c', 'D', 'e' };

        // Act
        Program.ConvierteMayusculasMinusculas(caracteres);

        // Assert
        Assert.Equal(esperado, caracteres);
    }

    [Fact]
    public void ConvertirMayusculasMinusculas_ConSoloMayusculas_DeberiaConvertirTodasAMinusculas()
    {
        // Arrange
        char[] caracteres = { 'A', 'B', 'C', 'D', 'E' };
        char[] esperado = { 'a', 'b', 'c', 'd', 'e' };

        // Act
        Program.ConvierteMayusculasMinusculas(caracteres);

        // Assert
        Assert.Equal(esperado, caracteres);
    }

    [Fact]
    public void ConvertirMayusculasMinusculas_ConSoloMinusculas_DeberiaConvertirTodasAMayusculas()
    {
        // Arrange
        char[] caracteres = { 'a', 'b', 'c', 'd', 'e' };
        char[] esperado = { 'A', 'B', 'C', 'D', 'E' };

        // Act
        Program.ConvierteMayusculasMinusculas(caracteres);

        // Assert
        Assert.Equal(esperado, caracteres);
    }

    [Fact]
    public void MuestraArray_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        char[] caracteres = { 'A', 'b', 'C' };

        try
        {
            // Act
            Program.MuestraArray(caracteres, "Test:");

            // Assert
            var result = output.ToString();
            Assert.Contains("Test:", result);
            Assert.Contains("A ", result);
            Assert.Contains("b ", result);
            Assert.Contains("C ", result);
        }
        finally
        {
            // Restore original output
            Console.SetOut(originalOutput);
        }
    }
}
