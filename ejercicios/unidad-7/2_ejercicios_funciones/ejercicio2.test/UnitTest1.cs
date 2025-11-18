using System;
using System.IO;
using Xunit;

namespace ejercicio2.test;

public class UnitTest1
{
    [Fact]
    public void NumeroAAdivinar_DeberiaEstarEnRango()
    {
        // Act
        int numero = Program.NumeroAAdivinar();

        // Assert
        Assert.InRange(numero, 0, 100);
    }

    [Fact]
    public void Pista_NumeroMayor_DeberiaRetornarFalse()
    {
        // Arrange
        var input = "75\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);
        int numeroAAdivinar = 50;

        // Act
        bool resultado = Program.Pista(numeroAAdivinar);

        // Assert
        Assert.False(resultado);
        Assert.Contains("El número es menor", output.ToString());
    }

    [Fact]
    public void Pista_NumeroMenor_DeberiaRetornarFalse()
    {
        // Arrange
        var input = "25\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);
        int numeroAAdivinar = 50;

        // Act
        bool resultado = Program.Pista(numeroAAdivinar);

        // Assert
        Assert.False(resultado);
        Assert.Contains("El número es mayor", output.ToString());
    }

    [Fact]
    public void Pista_NumeroIgual_DeberiaRetornarTrue()
    {
        // Arrange
        var input = "50\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);
        int numeroAAdivinar = 50;

        // Act
        bool resultado = Program.Pista(numeroAAdivinar);

        // Assert
        Assert.True(resultado);
        Assert.Contains("¡Felicidades! Has adivinado el número", output.ToString());
    }

    [Fact]
    public void Nivel_OpcionFacil_DeberiaRetornar10()
    {
        // Arrange
        var input = "1\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int tentativas = Program.Nivel();

        // Assert
        Assert.Equal(10, tentativas);
    }

    [Fact]
    public void Nivel_OpcionMedio_DeberiaRetornar6()
    {
        // Arrange
        var input = "2\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int tentativas = Program.Nivel();

        // Assert
        Assert.Equal(6, tentativas);
    }

    [Fact]
    public void Nivel_OpcionDificil_DeberiaRetornar4()
    {
        // Arrange
        var input = "3\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int tentativas = Program.Nivel();

        // Assert
        Assert.Equal(4, tentativas);
    }

    [Fact]
    public void Nivel_OpcionInvalidaLuegoValida_DeberiaRepetirYRetornarCorrect()
    {
        // Arrange
        var input = "5\n0\n2\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int tentativas = Program.Nivel();

        // Assert
        Assert.Equal(6, tentativas);
        var resultado = output.ToString();
        Assert.Contains("Opción no válida", resultado);
    }
}
