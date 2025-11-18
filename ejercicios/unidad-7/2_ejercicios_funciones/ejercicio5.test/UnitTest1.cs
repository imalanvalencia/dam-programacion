using System;
using System.IO;
using Xunit;

namespace ejercicio5.test;

public class UnitTest1
{
    [Fact]
    public void ValorAbsoluto_NumeroPositivo_DeberiaRetornarMismo()
    {
        // Act
        int resultado = Program.ValorAbsoluto(5);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ValorAbsoluto_NumeroNegativo_DeberiaRetornarPositivo()
    {
        // Act
        int resultado = Program.ValorAbsoluto(-5);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ValorAbsoluto_Cero_DeberiaRetornarCero()
    {
        // Act
        int resultado = Program.ValorAbsoluto(0);

        // Assert
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void EsPar_NumeroPar_DeberiaRetornarTrue()
    {
        // Act
        bool resultado = Program.EsPar(4);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void EsPar_NumeroImpar_DeberiaRetornarFalse()
    {
        // Act
        bool resultado = Program.EsPar(5);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void EsPar_Cero_DeberiaRetornarTrue()
    {
        // Act
        bool resultado = Program.EsPar(0);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void EsPrimo_NumeroPrimo_DeberiaRetornarTrue()
    {
        // Act
        bool resultado = Program.EsPrimo(7);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void EsPrimo_NumeroCompuesto_DeberiaRetornarFalse()
    {
        // Act
        bool resultado = Program.EsPrimo(8);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void EsPrimo_Numero1_DeberiaRetornarFalse()
    {
        // Act
        bool resultado = Program.EsPrimo(1);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void EsPrimo_Numero2_DeberiaRetornarTrue()
    {
        // Act
        bool resultado = Program.EsPrimo(2);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void EsPrimo_Numero3_DeberiaRetornarTrue()
    {
        // Act
        bool resultado = Program.EsPrimo(3);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void Maximo_PrimeroMayor_DeberiaRetornarPrimero()
    {
        // Act
        int resultado = Program.Maximo(10, 5);

        // Assert
        Assert.Equal(10, resultado);
    }

    [Fact]
    public void Maximo_SegundoMayor_DeberiaRetornarSegundo()
    {
        // Act
        int resultado = Program.Maximo(3, 8);

        // Assert
        Assert.Equal(8, resultado);
    }

    [Fact]
    public void Maximo_NumerosIguales_DeberiaRetornarCualquiera()
    {
        // Act
        int resultado = Program.Maximo(7, 7);

        // Assert
        Assert.Equal(7, resultado);
    }

    [Fact]
    public void Minimo_PrimeroMenor_DeberiaRetornarPrimero()
    {
        // Act
        int resultado = Program.Minimo(3, 8);

        // Assert
        Assert.Equal(3, resultado);
    }

    [Fact]
    public void Minimo_SegundoMenor_DeberiaRetornarSegundo()
    {
        // Act
        int resultado = Program.Minimo(10, 5);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void Minimo_NumerosIguales_DeberiaRetornarCualquiera()
    {
        // Act
        int resultado = Program.Minimo(7, 7);

        // Assert
        Assert.Equal(7, resultado);
    }

    [Fact]
    public void Minimo_NumerosNegativos_DeberiaRetornarMenor()
    {
        // Act
        int resultado = Program.Minimo(-5, -10);

        // Assert
        Assert.Equal(-10, resultado);
    }

    [Fact]
    public void Maximo_NumerosNegativos_DeberiaRetornarMayor()
    {
        // Act
        int resultado = Program.Maximo(-5, -10);

        // Assert
        Assert.Equal(-5, resultado);
    }
}
