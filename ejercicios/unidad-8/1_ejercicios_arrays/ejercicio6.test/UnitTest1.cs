using System;
using System.IO;
using Xunit;

namespace ejercicio6.test;

public class UnitTest1
{
    [Fact]
    public void LeeCalificaciones_DeberiaLeerCalificacionesCorrectamente()
    {
        // Arrange
        var input = "3\n8,5\n6,2\n9,1\n";
        Console.SetIn(new StringReader(input));

        // Act
        double[] resultado = Program.LeeCalificaciones();

        // Assert
        Assert.Equal(3, resultado.Length);
        Assert.Equal(8.5, resultado[0], 1);
        Assert.Equal(6.2, resultado[1], 1);
        Assert.Equal(9.1, resultado[2], 1);
    }

    [Fact]
    public void CalculaPromedio_DeberiaCalcularPromedioCorrectamente()
    {
        // Arrange
        double[] calificaciones = { 8.5, 6.2, 9.1, 7.8 };

        // Act
        double resultado = Program.CalculaPromedio(calificaciones);

        // Assert
        Assert.Equal(7.9, resultado, 1);
    }

    [Fact]
    public void ObtieneMaxima_DeberiaRetornarLaMaxima()
    {
        // Arrange
        double[] calificaciones = { 8.5, 6.2, 9.1, 7.8 };

        // Act
        double resultado = Program.ObtieneMaxima(calificaciones);

        // Assert
        Assert.Equal(9.1, resultado, 1);
    }

    [Fact]
    public void ObtieneMinima_DeberiaRetornarLaMinima()
    {
        // Arrange
        double[] calificaciones = { 8.5, 6.2, 9.1, 7.8 };

        // Act
        double resultado = Program.ObtieneMinima(calificaciones);

        // Assert
        Assert.Equal(6.2, resultado, 1);
    }

    [Fact]
    public void CuentaAprobados_DeberiaContarAprobadosCorrectamente()
    {
        // Arrange
        double[] calificaciones = { 8.5, 4.2, 9.1, 7.8, 3.5 };

        // Act
        int resultado = Program.CuentaAprobados(calificaciones);

        // Assert
        Assert.Equal(3, resultado); // 8.5, 9.1, 7.8 están >= 5.0
    }

    [Fact]
    public void CuentaAprobados_ConTodosAprobados_DeberiaRetornarTotal()
    {
        // Arrange
        double[] calificaciones = { 8.5, 6.2, 9.1, 7.8 };

        // Act
        int resultado = Program.CuentaAprobados(calificaciones);

        // Assert
        Assert.Equal(4, resultado);
    }

    [Fact]
    public void MuestraEstadisticas_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] calificaciones = { 8.5, 6.2, 9.1 };

        // Act
        Program.MuestraEstadisticas(calificaciones);

        // Assert
        var result = output.ToString();
        Assert.Contains("ESTADÍSTICAS DE LA CLASE", result);
        Assert.Contains("Calificaciones:", result);
        Assert.Contains("Promedio de la clase:", result);
        Assert.Contains("Calificación más alta:", result);
        Assert.Contains("Calificación más baja:", result);
        Assert.Contains("Número de aprobados:", result);
        Assert.Contains("Número de suspensos:", result);
    }
}
