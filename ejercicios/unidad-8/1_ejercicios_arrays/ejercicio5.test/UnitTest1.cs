using System;
using System.IO;
using Xunit;

namespace ejercicio5.test;

public class UnitTest1
{
    [Fact]
    public void LeeNumeros_DeberiaLeer10Numeros()
    {
        // Arrange
        var input = "10\n20\n30\n40\n50\n60\n70\n80\n90\n100\n";
        Console.SetIn(new StringReader(input));

        // Act
        int[] resultado = Program.LeeNumeros();

        // Assert
        Assert.Equal(10, resultado.Length);
        Assert.Equal(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, resultado);
    }

    [Fact]
    public void DesplazaDerechaCircular_DeberiaDesplazarCorrectamente()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        int[] esperado = { 100, 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        // Act
        Program.DesplazaDerechaCircular(array);

        // Assert
        Assert.Equal(esperado, array);
    }

    [Fact]
    public void DesplazaDerechaCircular_ConUnElemento_NoDeberaCambiar()
    {
        // Arrange  
        int[] array = { 42 };
        int[] esperado = { 42 };

        // Act
        Program.DesplazaDerechaCircular(array);

        // Assert
        Assert.Equal(esperado, array);
    }

    [Fact]
    public void DesplazaDerechaCircular_ConDosElementos_DeberiaIntercambiar()
    {
        // Arrange
        int[] array = { 1, 2 };
        int[] esperado = { 2, 1 };

        // Act
        Program.DesplazaDerechaCircular(array);

        // Assert
        Assert.Equal(esperado, array);
    }

    [Fact]
    public void DesplazaDerechaCircularConRangos_DeberiaDesplazarCorrectamente()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int[] esperado = { 50, 10, 20, 30, 40 };

        // Act
        array = Program.DesplazaDerechaCircularConRangos(array);

        // Assert
        Assert.Equal(esperado, array);
    }

    [Fact]
    public void MuestrarArray_DeberiaGenerarSalidaCorrecta()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        int[] array = { 1, 2, 3 };

        // Act
        Program.MuestraArray(array);

        // Assert
        var result = output.ToString();
        Assert.Contains("[1, 2, 3]", result);
    }


}
