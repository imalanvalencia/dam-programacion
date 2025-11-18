using System;
using System.IO;
using Xunit;

namespace ejercicio4.test;

public class UnitTest1
{
    [Fact]
    public void PasaABinario_Numero6_DeberiaRetornar110()
    {
        // Act
        string resultado = Program.PasaABinario(6);

        // Assert
        Assert.Equal("110", resultado);
    }

    [Fact]
    public void PasaABinario_Numero0_DeberiaRetornar0()
    {
        // Act
        string resultado = Program.PasaABinario(0);

        // Assert
        Assert.Equal("0", resultado);
    }

    [Fact]
    public void PasaABinario_Numero15_DeberiaRetornar1111()
    {
        // Act
        string resultado = Program.PasaABinario(15);

        // Assert
        Assert.Equal("1111", resultado);
    }

    [Fact]
    public void PasaABinario_NumeroNegativo_DeberiaRetornarConSigno()
    {
        // Act
        string resultado = Program.PasaABinario(-6);

        // Assert
        Assert.Equal("-110", resultado);
    }

    [Fact]
    public void PasaAOctal_Numero64_DeberiaRetornar100()
    {
        // Act
        string resultado = Program.PasaAOctal(64);

        // Assert
        Assert.Equal("100", resultado);
    }

    [Fact]
    public void PasaAOctal_Numero8_DeberiaRetornar10()
    {
        // Act
        string resultado = Program.PasaAOctal(8);

        // Assert
        Assert.Equal("10", resultado);
    }

    [Fact]
    public void PasaAOctal_Numero7_DeberiaRetornar7()
    {
        // Act
        string resultado = Program.PasaAOctal(7);

        // Assert
        Assert.Equal("7", resultado);
    }

    [Fact]
    public void PasaAHexadecimal_Numero255_DeberiaRetornarFF()
    {
        // Act
        string resultado = Program.PasaAHexadecimal(255);

        // Assert
        Assert.Equal("FF", resultado);
    }

    [Fact]
    public void PasaAHexadecimal_Numero16_DeberiaRetornar10()
    {
        // Act
        string resultado = Program.PasaAHexadecimal(16);

        // Assert
        Assert.Equal("10", resultado);
    }

    [Fact]
    public void PasaAHexadecimal_Numero10_DeberiaRetornarA()
    {
        // Act
        string resultado = Program.PasaAHexadecimal(10);

        // Assert
        Assert.Equal("A", resultado);
    }

    [Fact]
    public void PasaAHexadecimal_Numero15_DeberiaRetornarF()
    {
        // Act
        string resultado = Program.PasaAHexadecimal(15);

        // Assert
        Assert.Equal("F", resultado);
    }

    [Fact]
    public void PasaAHexadecimal_Numero171_DeberiaRetornarAB()
    {
        // Act
        string resultado = Program.PasaAHexadecimal(171); // 10*16 + 11 = 171

        // Assert
        Assert.Equal("AB", resultado);
    }

    [Fact]
    public void MostrarMenu_DeberiaRetornarOpcionValida()
    {
        // Arrange
        var input = "1\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int opcion = Program.MostrarMenu();

        // Assert
        Assert.InRange(opcion, 1, 4);
        var outputText = output.ToString();
        Assert.Contains("CONVERSOR DE BASES", outputText);
        Assert.Contains("Convertir a binario", outputText);
        Assert.Contains("Convertir a octal", outputText);
        Assert.Contains("Convertir a hexadecimal", outputText);
    }

    [Fact]
    public void MostrarMenu_OpcionInvalidaLuegoValida_DeberiaRepetir()
    {
        // Arrange
        var input = "0\n5\n2\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int opcion = Program.MostrarMenu();

        // Assert
        Assert.Equal(2, opcion);
        var outputText = output.ToString();
        Assert.Contains("Opción no válida", outputText);
    }
}
