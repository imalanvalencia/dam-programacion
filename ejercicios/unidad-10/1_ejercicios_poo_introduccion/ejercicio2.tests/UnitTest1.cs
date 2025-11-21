using System;
using Ejercicio2;

namespace ejercicio2.tests;

public class UnitTest1
{
    [Theory]
    [InlineData(5.0, 3.0, 8.0)]
    [InlineData(10.5, 2.5, 13.0)]
    [InlineData(-5.0, 3.0, -2.0)]
    public void CalculadoraEstatica_Suma_DebeRetornarResultadoCorrecto(double a, double b, double esperado)
    {
        // Act
        double resultado = CalculadoraEstatica.Suma(a, b);
        
        // Assert
        Assert.Equal(esperado, resultado, 2);
    }

    [Theory]
    [InlineData(5.0, 3.0, 2.0)]
    [InlineData(10.5, 2.5, 8.0)]
    [InlineData(-5.0, 3.0, -8.0)]
    public void CalculadoraEstatica_Resta_DebeRetornarResultadoCorrecto(double a, double b, double esperado)
    {
        // Act
        double resultado = CalculadoraEstatica.Resta(a, b);
        
        // Assert
        Assert.Equal(esperado, resultado, 2);
    }

    [Theory]
    [InlineData(5.0, 3.0, 15.0)]
    [InlineData(10.5, 2.0, 21.0)]
    [InlineData(-5.0, 3.0, -15.0)]
    public void CalculadoraEstatica_Multiplica_DebeRetornarResultadoCorrecto(double a, double b, double esperado)
    {
        // Act
        double resultado = CalculadoraEstatica.Multiplica(a, b);
        
        // Assert
        Assert.Equal(esperado, resultado, 2);
    }

    [Theory]
    [InlineData(6.0, 3.0, 2.0)]
    [InlineData(10.0, 2.0, 5.0)]
    [InlineData(15.0, 3.0, 5.0)]
    public void CalculadoraEstatica_Divide_DebeRetornarResultadoCorrecto(double a, double b, double esperado)
    {
        // Act
        double resultado = CalculadoraEstatica.Divide(a, b);
        
        // Assert
        Assert.Equal(esperado, resultado, 2);
    }

    [Fact]
    public void CalculadoraTAD_Constructor_DebeInicializarValores()
    {
        // Arrange
        double valor1 = 10.5;
        double valor2 = 5.2;
        
        // Act
        CalculadoraTAD calc = new CalculadoraTAD(valor1, valor2);
        
        // Assert
        Assert.Equal(valor1, calc.Valor1);
        Assert.Equal(valor2, calc.Valor2);
    }

    [Fact]
    public void CalculadoraTAD_Suma_DebeRetornarSumaDeValores()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        
        // Act
        double resultado = calc.Suma();
        
        // Assert
        Assert.Equal(15.0, resultado);
    }

    [Fact]
    public void CalculadoraTAD_Resta_DebeRetornarRestaDeValores()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        
        // Act
        double resultado = calc.Resta();
        
        // Assert
        Assert.Equal(5.0, resultado);
    }

    [Fact]
    public void CalculadoraTAD_Multiplica_DebeRetornarMultiplicacionDeValores()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        
        // Act
        double resultado = calc.Multiplica();
        
        // Assert
        Assert.Equal(50.0, resultado);
    }

    [Fact]
    public void CalculadoraTAD_Divide_DebeRetornarDivisionDeValores()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        
        // Act
        double resultado = calc.Divide();
        
        // Assert
        Assert.Equal(2.0, resultado);
    }

    [Fact]
    public void CalculadoraTAD_CambiaValores_DebeModificarValores()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        double nuevoValor1 = 20.0;
        double nuevoValor2 = 3.0;
        
        // Act
        calc.CambiaValores(nuevoValor1, nuevoValor2);
        
        // Assert
        Assert.Equal(nuevoValor1, calc.Valor1);
        Assert.Equal(nuevoValor2, calc.Valor2);
    }

    [Fact]
    public void CalculadoraTAD_ObjetosIndependientes_DebenSerDiferentes()
    {
        // Arrange
        CalculadoraTAD calc1 = new CalculadoraTAD(10.0, 5.0);
        CalculadoraTAD calc2 = new CalculadoraTAD(20.0, 3.0);
        
        // Act & Assert
        Assert.False(ReferenceEquals(calc1, calc2));
        Assert.NotEqual(calc1.Valor1, calc2.Valor1);
        Assert.NotEqual(calc1.Valor2, calc2.Valor2);
    }

    [Fact]
    public void CalculadoraTAD_ModificacionIndependiente_NoAfectaOtrosObjetos()
    {
        // Arrange
        CalculadoraTAD calc1 = new CalculadoraTAD(10.0, 5.0);
        CalculadoraTAD calc2 = new CalculadoraTAD(10.0, 5.0);
        
        // Act
        calc1.CambiaValores(20.0, 3.0);
        
        // Assert
        Assert.NotEqual(calc1.Valor1, calc2.Valor1);
        Assert.NotEqual(calc1.Valor2, calc2.Valor2);
        Assert.Equal(10.0, calc2.Valor1);
        Assert.Equal(5.0, calc2.Valor2);
    }

    [Fact]
    public void CalculadoraTAD_MuestraEstado_NoDebeGenerarExcepcion()
    {
        // Arrange
        CalculadoraTAD calc = new CalculadoraTAD(10.0, 5.0);
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        // Act & Assert
        var exception = Record.Exception(() => calc.MuestraEstado());
        Assert.Null(exception);
        
        string output = stringWriter.ToString();
        Assert.Contains("10", output);
        Assert.Contains("5", output);
    }
}
