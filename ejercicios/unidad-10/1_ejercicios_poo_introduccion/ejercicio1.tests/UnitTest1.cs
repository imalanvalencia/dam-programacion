using System;
using System.Drawing;

namespace ejercicio1.tests;

public class UnitTest1
{
    [Fact]
    public void GeneraColor_DebeRetornarColorValido()
    {
        // Act
        ConsoleColor color = Program.GeneraColor();
        
        // Assert
        Assert.True(Enum.IsDefined(typeof(ConsoleColor), color));
    }

    [Fact]
    public void GeneraColor_DebeRetornarColorDiferente_EnLlamadasMultiples()
    {
        // Arrange
        var colores = new HashSet<ConsoleColor>();
        
        // Act - Generar varios colores
        for (int i = 0; i < 20; i++)
        {
            colores.Add(Program.GeneraColor());
        }
        
        // Assert - Debe haber al menos 2 colores diferentes
        Assert.True(colores.Count >= 2, "Se esperaban al menos 2 colores diferentes en 20 intentos");
    }

    [Fact]
    public void Point_DebeEncapsularCoordenadas()
    {
        // Arrange
        int x = 5;
        int y = 10;
        
        // Act
        Point punto = new Point(x, y);
        
        // Assert
        Assert.Equal(x, punto.X);
        Assert.Equal(y, punto.Y);
    }

    [Fact]
    public void Point_DebeSerTipoDeValor()
    {
        // Arrange
        Point punto1 = new Point(5, 10);
        Point punto2 = punto1; // Copia por ser struct
        
        // Act
        punto2 = new Point(15, 20); // Modificar la copia
        
        // Assert
        Assert.NotEqual(punto1, punto2);
        Assert.Equal(5, punto1.X);
        Assert.Equal(10, punto1.Y);
    }
}
