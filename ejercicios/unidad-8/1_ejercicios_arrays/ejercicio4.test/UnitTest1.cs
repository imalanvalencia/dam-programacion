using System;
using System.IO;
using Xunit;

namespace ejercicio4.test;

public class UnitTest1
{
    [Fact]
    public void LeeNumero_DeberiaLeerEntradaCorrecta()
    {
        // Arrange
        var input = "12321\n";
        Console.SetIn(new StringReader(input));

        // Act
        char[] resultado = Program.LeeNumero();

        // Assert
        Assert.Equal("12321", new string(resultado));
    }

    [Fact]
    public void EsCapicua_ConNumeroCapicua_DeberiaRetornarTrue()
    {
        // Arrange
        var numero = "1234321".ToCharArray();

        // Act
        bool resultado = Program.EsCapicua(numero);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void EsCapicua_ConNumeroNoCapicua_DeberiaRetornarFalse()
    {
        // Arrange
        var numero = "12345".ToCharArray();

        // Act
        bool resultado = Program.EsCapicua(numero);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void EsCapicua_ConUnSoloDigito_DeberiaRetornarTrue()
    {
        // Arrange
        char[] numero = "5".ToCharArray();

        // Act
        bool resultado = Program.EsCapicua(numero);

        // Assert
        Assert.True(resultado);
    }

}
