using System;
using System.IO;
using Xunit;

namespace ejercicio3.test;

public class UnitTest1
{
    [Fact]
    public void PresentaJuego_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        Program.PresentaJuego();

        // Assert
        var result = output.ToString();
        Assert.Contains("Reglas del juego", result);
        Assert.Contains("Múltiplo de 3 o 5: +10 pts", result);
        Assert.Contains("Múltiplo de 4 o 6: +5 pts", result);
        Assert.Contains("Mayor de 80: +2 pts", result);
    }

    [Fact]
    public void PideNumeroParticipantes_NumeroValido_DeberiaRetornarNumero()
    {
        // Arrange
        var input = "5\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int resultado = Program.PideNumeroParticipantes();

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void PideNumeroParticipantes_NumeroInvalidoLuegoValido_DeberiaRepetir()
    {
        // Arrange
        var input = "0\n-1\n3\n";
        Console.SetIn(new StringReader(input));
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        int resultado = Program.PideNumeroParticipantes();

        // Assert
        Assert.Equal(3, resultado);
        var outputText = output.ToString();
        Assert.Contains("número válido mayor que 0", outputText);
    }

    [Fact]
    public void TiraDado_DeberiaEstarEnRango()
    {
        // Act
        int resultado = Program.TiraDado();

        // Assert
        Assert.InRange(resultado, 1, 100);
    }

    [Fact]
    public void CalculaPuntos_MultiploDe3_DeberiaOtorgar10Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(9); // Múltiplo de 3

        // Assert
        Assert.Equal(7, puntos);
    }

    [Fact]
    public void CalculaPuntos_MultiploDe5_DeberiaOtorgar10Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(25); // Múltiplo de 5

        // Assert
        Assert.Equal(8, puntos);
    }

    [Fact]
    public void CalculaPuntos_MultiploDe4_DeberiaOtorgar5Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(8); // Múltiplo de 4

        // Assert
        Assert.Equal(2, puntos);
    }

    [Fact]
    public void CalculaPuntos_MultiploDe6_DeberiaOtorgar5Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(18); // Múltiplo de 6

        // Assert
        Assert.Equal(12, puntos);
    }

    [Fact]
    public void CalculaPuntos_MayorDe80_DeberiaOtorgar2Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(85);

        // Assert
        Assert.Equal(13, puntos);
    }

    [Fact]
    public void CalculaPuntos_MayorDe50_DeberiaOtorgar1Punto()
    {
        // Act
        int puntos = Program.CalculaPuntos(55);

        // Assert
        Assert.Equal(11, puntos);
    }

    [Fact]
    public void CalculaPuntos_MenorDe50_DeberiaRestar2Puntos()
    {
        // Act
        int puntos = Program.CalculaPuntos(45);

        // Assert
        Assert.Equal(8, puntos);
    }

    [Fact]
    public void CalculaPuntos_MenorDe20_DeberiaRestar1PuntoAdicional()
    {
        // Act
        int puntos = Program.CalculaPuntos(15);

        // Assert
        Assert.Equal(7, puntos);
    }

    [Fact]
    public void CalculaPuntos_CasoCombinado_DeberiaAcumularPuntos()
    {
        int puntos = Program.CalculaPuntos(30);

        // Assert
        Assert.Equal(13, puntos);
    }
}
