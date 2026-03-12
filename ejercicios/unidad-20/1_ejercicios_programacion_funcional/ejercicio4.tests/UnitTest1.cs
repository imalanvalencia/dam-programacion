using Xunit;
using Ejercicio4;
using System;
using System.IO;

namespace ejercicio4.tests;

public class UnitTest1
{
    [Fact]
    public void Calculos_Cuadrado_RetornaCuadrado()
    {
        Assert.Equal(25, Calculos.Cuadrado(5));
    }

    [Fact]
    public void Calculos_Cubo_RetornaCubo()
    {
        Assert.Equal(27, Calculos.Cubo(3));
    }

    [Fact]
    public void ReglasDescuento_DescuentoPorCantidad_CalculaCorrectamente()
    {
        Assert.Equal(15, ReglasDescuento.DescuentoPorCantidad(100, 11, false));
    }

   
    [Fact]
    public void ProcesaPedido_ImprimeCorrectamente()
    {
        // Arrange
        double importe = 100;
        int cantidad = 1;
        bool esVip = true;
        Func<double, int, bool, double> calculo = ReglasDescuento.DescuentoVip;
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Ejercicio2.ProcesaPedido(importe, cantidad, esVip, calculo);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Descuento aplicado: 20", output);
    }
}
