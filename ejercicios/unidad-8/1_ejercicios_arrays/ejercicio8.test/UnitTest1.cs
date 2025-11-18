using System;
using System.IO;
using Xunit;

namespace ejercicio8.test;

public class UnitTest1
{
    [Fact]
    public void LeeVentasMensuales_DeberiaLeer12Meses()
    {
        // Arrange
        var input = "15000,50\n18500,75\n22000,00\n19500,25\n25000,80\n28000,90\n32000,60\n29500,45\n26500,30\n24000,15\n27500,85\n35000,20\n";
        Console.SetIn(new StringReader(input));

        // Act
        double[] resultado = Program.LeeVentasMensuales();

        // Assert
        Assert.Equal(12, resultado.Length);
        Assert.Equal(15000.50, resultado[0], 2);
        Assert.Equal(35000.20, resultado[11], 2);
    }

    [Fact]
    public void CalculaVentasTrimestrales_DeberiaCalcularCorrectamente()
    {
        // Arrange
        double[] ventas = { 15000, 18000, 22000, 19500, 25000, 28000, 32000, 29500, 26500, 24000, 27500, 35000 };

        // Act
        double[] resultado = Program.CalculaVentasTrimestrales(ventas);

        // Assert
        Assert.Equal(4, resultado.Length);
        Assert.Equal(55000, resultado[0]); // Q1: 15000+18000+22000
        Assert.Equal(72500, resultado[1]); // Q2: 19500+25000+28000
        Assert.Equal(88000, resultado[2]); // Q3: 32000+29500+26500
        Assert.Equal(86500, resultado[3]); // Q4: 24000+27500+35000
    }

    [Fact]
    public void BuscaMejorTrimestre_DeberiaRetornarElMejor()
    {
        // Arrange
        double[] ventasTrimestrales = { 55000, 72500, 88000, 86500 };

        // Act
        var (trimestre, ventas) = Program.BuscaMejorTrimestre(ventasTrimestrales);

        // Assert
        Assert.Equal(3, trimestre); // Q3
        Assert.Equal(88000, ventas);
    }

    [Fact]
    public void MuestraMesesSuperioresAlPromedio_DeberiaMostrarSoloLosSuperiors()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        double[] ventas = { 15000, 25000, 18000, 30000 };
        // Promedio = (15000 + 25000 + 18000 + 30000) / 4 = 22000

        // Act
        Program.MuestraMesesSuperioresAlPromedio(ventas);

        // Assert
        var result = output.ToString();
        Assert.Contains("Promedio mensual:22.000,00€", result);
        Assert.Contains("Febrero: 25.000,00€", result); // 25000 > 22000
        Assert.Contains("Abril: 30.000,00€", result);   // 30000 > 22000
        Assert.DoesNotContain("Enero:", result);  // 15000 < 22000
        Assert.DoesNotContain("Marzo:", result);  // 18000 < 22000
    }
}
