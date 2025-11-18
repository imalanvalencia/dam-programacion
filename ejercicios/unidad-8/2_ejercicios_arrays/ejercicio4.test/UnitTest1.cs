namespace ejercicio4.test;

public class UnitTest1
{
    [Fact]
    public void ColorMasAlto_DebeEncontrarElColorMasAlto()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {1, 3, 2, 1},
            new int[] {4, 4, 2},
            new int[] {2, 1, 3, 3, 5},
            new int[] {3, 2}
        };

        // Act
        int resultado = Program.ColorMasAlto(jardin);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ColorMasAlto_ConUnSoloColor_DebeRetornarEseColor()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {3, 3, 3},
            new int[] {3}
        };

        // Act
        int resultado = Program.ColorMasAlto(jardin);

        // Assert
        Assert.Equal(3, resultado);
    }

    [Fact]
    public void CuentaFloresPorColor_DebeContarCorrectamente()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {1, 3, 2, 1},
            new int[] {4, 4, 2},
            new int[] {2, 1, 3, 3, 5},
            new int[] {3, 2}
        };

        // Act
        int[] resultado = Program.CuentaFloresPorColor(jardin);

        // Assert
        Assert.Equal(5, resultado.Length); // Colores del 1 al 5
        Assert.Equal(3, resultado[0]); // Color 1: 3 flores
        Assert.Equal(4, resultado[1]); // Color 2: 4 flores
        Assert.Equal(4, resultado[2]); // Color 3: 4 flores
        Assert.Equal(2, resultado[3]); // Color 4: 2 flores
        Assert.Equal(1, resultado[4]); // Color 5: 1 flor
    }

    [Fact]
    public void CuentaFloresPorColor_ConJardinVacio_DebeRetornarArrayVacio()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {},
            new int[] {}
        };

        // Act & Assert
        // Este test verifica que el método no falle con arrays vacíos
        var exception = Record.Exception(() => Program.CuentaFloresPorColor(jardin));
        Assert.NotNull(exception); // Se espera una excepción porque no hay elementos para encontrar el color más alto
    }

    [Fact]
    public void Muestra_NoDebeGenerarExcepcion()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {4, 5}
        };

        // Act & Assert
        var exception = Record.Exception(() => Program.Muestra(jardin));
        Assert.Null(exception);
    }

    [Fact]
    public void MuestraInventarioColoresFlores_NoDebeGenerarExcepcion()
    {
        // Arrange
        int[] inventario = new int[] {3, 4, 4, 2, 1};

        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraInventarioColoresFlores(inventario));
        Assert.Null(exception);
    }

    [Fact]
    public void MuestraInventarioColoresFlores_ConCerosEnInventario_NoDebeGenerar()
    {
        // Arrange
        int[] inventario = new int[] {0, 2, 0, 1, 0};

        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraInventarioColoresFlores(inventario));
        Assert.Null(exception);
    }

    [Fact]
    public void ColorMasAlto_ConColoresNegativos_DebeEncontrarElMayor()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {-1, -3, -2},
            new int[] {-5, -4}
        };

        // Act
        int resultado = Program.ColorMasAlto(jardin);

        // Assert
        Assert.Equal(-1, resultado);
    }

    [Fact]
    public void CuentaFloresPorColor_ConVariosColores_DebeContarTodos()
    {
        // Arrange
        int[][] jardin = new int[][]
        {
            new int[] {1, 1, 2},
            new int[] {2, 2, 3},
            new int[] {3, 3, 3}
        };

        // Act
        int[] resultado = Program.CuentaFloresPorColor(jardin);

        // Assert
        Assert.Equal(3, resultado.Length);
        Assert.Equal(2, resultado[0]); // Color 1: 2 flores
        Assert.Equal(3, resultado[1]); // Color 2: 3 flores
        Assert.Equal(4, resultado[2]); // Color 3: 4 flores
    }
}
