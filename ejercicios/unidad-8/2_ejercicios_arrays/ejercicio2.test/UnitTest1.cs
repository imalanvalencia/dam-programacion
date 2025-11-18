namespace ejercicio2.test;

public class UnitTest1
{
    [Fact]
    public void CreaArrayIdentidad_DebeCrearArrayConDimensionesCorrectas()
    {
        // Arrange
        int tamaño = 5;

        // Act
        int[][] resultado = Program.CreaArrayIdentidad(tamaño);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(tamaño, resultado.Length);
        for (int i = 0; i < resultado.Length; i++)
        {
            Assert.NotNull(resultado[i]);
            Assert.Equal(tamaño, resultado[i].Length);
        }
    }

    [Fact]
    public void CreaArrayIdentidad_ConTamañoDiferente_DebeCrearArrayCorrectamente()
    {
        // Arrange
        int tamaño = 3;

        // Act
        int[][] resultado = Program.CreaArrayIdentidad(tamaño);

        // Assert
        Assert.Equal(tamaño, resultado.Length);
        for (int i = 0; i < resultado.Length; i++)
        {
            Assert.Equal(tamaño, resultado[i].Length);
        }
    }

    [Fact]
    public void InicializaDiagonal_DebeColocarUnosEnDiagonalPrincipal()
    {
        // Arrange
        int[][] array = Program.CreaArrayIdentidad(4);

        // Act
        Program.InicializaDiagonal(array);

        // Assert
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                if (i == j)
                {
                    Assert.Equal(1, array[i][j]); // Diagonal principal
                }
                else
                {
                    Assert.Equal(0, array[i][j]); // Resto de elementos
                }
            }
        }
    }

    [Fact]
    public void InicializaDiagonal_Array5x5_DebeCrearMatrizIdentidad()
    {
        // Arrange
        int[][] array = Program.CreaArrayIdentidad(5);

        // Act
        Program.InicializaDiagonal(array);

        // Assert
        // Verificar diagonal principal
        for (int i = 0; i < 5; i++)
        {
            Assert.Equal(1, array[i][i]);
        }

        // Verificar algunos elementos fuera de la diagonal
        Assert.Equal(0, array[0][1]);
        Assert.Equal(0, array[1][0]);
        Assert.Equal(0, array[2][3]);
        Assert.Equal(0, array[3][2]);
        Assert.Equal(0, array[4][0]);
    }

    [Fact]
    public void MuestraArrayConForeach_NoDebeGenerarExcepcion()
    {
        // Arrange
        int[][] array = Program.CreaArrayIdentidad(3);
        Program.InicializaDiagonal(array);

        // Act & Assert
        var exception = Record.Exception(() => Program.MuestraArrayConForeach(array));
        Assert.Null(exception);
    }

    [Fact]
    public void InicializaDiagonal_ArrayTamaño1_DebeColocarUnoEnUnicaPosicion()
    {
        // Arrange
        int[][] array = Program.CreaArrayIdentidad(1);

        // Act
        Program.InicializaDiagonal(array);

        // Assert
        Assert.Equal(1, array[0][0]);
    }
}
