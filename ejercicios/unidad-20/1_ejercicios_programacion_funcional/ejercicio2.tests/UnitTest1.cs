using Xunit;
using Ejercicio2;
using System;
using System.IO;

namespace ejercicio2.tests;

public class UnitTest1
{
    [Fact]
    public void DescuentoPorCantidad_Aplica15PorcientoSiCantidadMayorA10()
    {
        double importe = 100;
        int cantidad = 11;
        bool esVip = false;
        double esperado = 15;

        double resultado = ReglasDescuento.DescuentoPorCantidad(importe, cantidad, esVip);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void DescuentoPorCantidad_Aplica5PorcientoSiCantidadMayorA5()
    {
        double importe = 100;
        int cantidad = 6;
        bool esVip = false;
        double esperado = 5;

        double resultado = ReglasDescuento.DescuentoPorCantidad(importe, cantidad, esVip);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void DescuentoVip_Aplica20PorcientoSiEsVip()
    {
        double importe = 100;
        int cantidad = 1;
        bool esVip = true;
        double esperado = 20;

        double resultado = ReglasDescuento.DescuentoVip(importe, cantidad, esVip);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void DescuentoCombinado_Aplica25PorcientoSiVipYCantidadMayorA5()
    {
        double importe = 100;
        int cantidad = 6;
        bool esVip = true;
        double esperado = 25;

        double resultado = ReglasDescuento.DescuentoCombinado(importe, cantidad, esVip);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void ProcesaPedido_ImprimeDescuentoYPrecioFinal()
    {
        // Arrange
        double importe = 100;
        int cantidad = 1;
        bool esVip = true;
        CalculoDescuento calculo = ReglasDescuento.DescuentoVip;
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Program.ProcesaPedido(importe, cantidad, esVip, calculo);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Descuento aplicado: 20", output);
        Assert.Contains("Precio Final: 80", output);
    }
}
