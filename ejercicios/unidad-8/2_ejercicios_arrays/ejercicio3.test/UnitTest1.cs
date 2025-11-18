namespace ejercicio3.test;

public class UnitTest1
{
    [Fact]
    public void CreaTranspuesta_DebeCrearArrayConDimensionesCorrectas()
    {
        // Arrange
        int[][] original = new int[][]
        {
            new int[] {1, 2, 3, 4, 5},
            new int[] {6, 7, 8, 9, 10},
            new int[] {11, 12, 13, 14, 15}
        };

        // Act
        int[][] transpuesto = Program.CreaTranspuesta(original);

        // Assert
        Assert.NotNull(transpuesto);
        Assert.Equal(5, transpuesto.Length); // 5 filas (columnas del original)
        for (int i = 0; i < transpuesto.Length; i++)
        {
            Assert.Equal(3, transpuesto[i].Length); // 3 columnas (filas del original)
        }
    }

    [Fact]
    public void CreaTranspuesta_DebeTransponerElementosCorrectamente()
    {
        // Arrange
        int[][] original = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6}
        };

        // Act
        int[][] transpuesto = Program.CreaTranspuesta(original);

        // Assert
        Assert.Equal(1, transpuesto[0][0]); // original[0][0] -> transpuesto[0][0]
        Assert.Equal(4, transpuesto[0][1]); // original[1][0] -> transpuesto[0][1]
        Assert.Equal(2, transpuesto[1][0]); // original[0][1] -> transpuesto[1][0]
        Assert.Equal(5, transpuesto[1][1]); // original[1][1] -> transpuesto[1][1]
        Assert.Equal(3, transpuesto[2][0]); // original[0][2] -> transpuesto[2][0]
        Assert.Equal(6, transpuesto[2][1]); // original[1][2] -> transpuesto[2][1]
    }

    [Fact]
    public void CreaTranspuesta_ArrayCompleto3x5_DebeTransponerCorrectamente()
    {
        // Arrange
        int[][] original = new int[][]
        {
            new int[] {-1, 2, 1, 4, 7},
            new int[] {-3, 3, 5, 8, 9},
            new int[] {6, 0, -2, 1, 3}
        };

        // Act
        int[][] transpuesto = Program.CreaTranspuesta(original);

        // Assert
        // Verificar dimensiones
        Assert.Equal(5, transpuesto.Length);
        Assert.Equal(3, transpuesto[0].Length);

        // Verificar algunos elementos específicos
        Assert.Equal(-1, transpuesto[0][0]); // original[0][0]
        Assert.Equal(-3, transpuesto[0][1]); // original[1][0]
        Assert.Equal(6, transpuesto[0][2]);  // original[2][0]
        
        Assert.Equal(2, transpuesto[1][0]);  // original[0][1]
        Assert.Equal(3, transpuesto[1][1]);  // original[1][1]
        Assert.Equal(0, transpuesto[1][2]);  // original[2][1]

        Assert.Equal(7, transpuesto[4][0]);  // original[0][4]
        Assert.Equal(9, transpuesto[4][1]);  // original[1][4]
        Assert.Equal(3, transpuesto[4][2]);  // original[2][4]
    }

    [Fact]
    public void MuestraArray_NoDebeGenerarExcepcion()
    {
        // Arrange
        int[][] array = new int[][]
        {
            new int[] {1, 2},
            new int[] {3, 4}
        };

        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraArray(array, "Test Array"));
        Assert.Null(exception);
    }

    [Fact]
    public void CreaTranspuesta_ArrayCuadrado_DebeTransponerCorrectamente()
    {
        // Arrange
        int[][] original = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9}
        };

        // Act
        int[][] transpuesto = Program.CreaTranspuesta(original);

        // Assert
        Assert.Equal(3, transpuesto.Length);
        Assert.Equal(3, transpuesto[0].Length);
        
        // Verificar transposición de matriz cuadrada
        Assert.Equal(1, transpuesto[0][0]);
        Assert.Equal(4, transpuesto[0][1]);
        Assert.Equal(7, transpuesto[0][2]);
        Assert.Equal(2, transpuesto[1][0]);
        Assert.Equal(5, transpuesto[1][1]);
        Assert.Equal(8, transpuesto[1][2]);
        Assert.Equal(3, transpuesto[2][0]);
        Assert.Equal(6, transpuesto[2][1]);
        Assert.Equal(9, transpuesto[2][2]);
    }
}
