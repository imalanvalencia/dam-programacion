using Xunit;
using Ejercicio1;
using System;
using System.IO;

namespace ejercicio1.tests;

public class UnitTest1
{
    [Fact]
    public void Cuadrado_RetornaElCuadradoDelNumero()
    {
        // Arrange
        int numero = 5;
        int esperado = 25;

        // Act
        int resultado = Calculos.Cuadrado(numero);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Cubo_RetornaElCuboDelNumero()
    {
        // Arrange
        int numero = 3;
        int esperado = 27;

        // Act
        int resultado = Calculos.Cubo(numero);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    
    
    
    [Fact]
    public void Operacion_DebeFuncionarComoDelegado()
    {
        // Arrange
        int numero = 4;
        Operacion operacion;

        // Act & Assert - Caso Cuadrado
        operacion = Calculos.Cuadrado;
        int resultadoCuadrado = operacion(numero);
        Assert.Equal(16, resultadoCuadrado);

        // Act & Assert - Caso Cubo
        operacion = Calculos.Cubo;
        int resultadoCubo = operacion(numero);
        Assert.Equal(64, resultadoCubo);
    }
}
