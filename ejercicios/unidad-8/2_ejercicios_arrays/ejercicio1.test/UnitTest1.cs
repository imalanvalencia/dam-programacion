namespace ejercicio1.test;

public class UnitTest1
{
    [Fact]
    public void CreaArray_DebeCrearArrayConDimensionesCorrectas()
    {
        // Arrange
        int filas = 10;
        int columnas = 10;

        // Act
        int[][] resultado = Program.CreaArray(filas, columnas);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(filas, resultado.Length);
        for (int i = 0; i < resultado.Length; i++)
        {
            Assert.NotNull(resultado[i]);
            Assert.Equal(columnas, resultado[i].Length);
        }
    }

    [Fact]
    public void CreaArray_ConDimensionesDiferentes_DebeCrearArrayCorrectamente()
    {
        // Arrange
        int filas = 5;
        int columnas = 8;

        // Act
        int[][] resultado = Program.CreaArray(filas, columnas);

        // Assert
        Assert.Equal(filas, resultado.Length);
        for (int i = 0; i < resultado.Length; i++)
        {
            Assert.Equal(columnas, resultado[i].Length);
        }
    }

    [Fact]
    public void RellenaConPatron_DebeRellenarConPatronAlternado()
    {
        // Arrange
        int[][] array = Program.CreaArray(4, 4);

        // Act
        Program.RellenaConPatron(array);

        // Assert
        // Fila 0 (par): todos unos
        for (int j = 0; j < array[0].Length; j++)
        {
            Assert.Equal(1, array[0][j]);
        }

        // Fila 1 (impar): todos ceros
        for (int j = 0; j < array[1].Length; j++)
        {
            Assert.Equal(0, array[1][j]);
        }

        // Fila 2 (par): todos unos
        for (int j = 0; j < array[2].Length; j++)
        {
            Assert.Equal(1, array[2][j]);
        }

        // Fila 3 (impar): todos ceros
        for (int j = 0; j < array[3].Length; j++)
        {
            Assert.Equal(0, array[3][j]);
        }
    }

    [Fact]
    public void RellenaConPatron_Array10x10_DebeRellenarCorrectamente()
    {
        // Arrange
        int[][] array = Program.CreaArray(10, 10);

        // Act
        Program.RellenaConPatron(array);

        // Assert
        for (int i = 0; i < array.Length; i++)
        {
            int valorEsperado = (i % 2 == 0) ? 1 : 0;
            for (int j = 0; j < array[i].Length; j++)
            {
                Assert.Equal(valorEsperado, array[i][j]);
            }
        }
    }

    [Fact]
    public void MuestraArray_NoDebeGenerarExcepcion()
    {
        // Arrange
        int[][] array = Program.CreaArray(3, 3);
        Program.RellenaConPatron(array);

        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraArray(array));
        Assert.Null(exception);
    }
}
