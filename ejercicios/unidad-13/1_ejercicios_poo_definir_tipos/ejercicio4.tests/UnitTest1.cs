using System;

namespace ejercicio4.tests;

public class VehiculoTests
{
    [Fact]
    public void Constructor_DeberiaAsignarPropiedadesCorrectamente()
    {
        // Arrange & Act
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 50000);
        
        // Assert
        Assert.Equal("1234ABC", vehiculo.Matricula);
        Assert.Equal("Toyota", vehiculo.Marca);
        Assert.Equal("Corolla", vehiculo.Modelo);
        Assert.Equal(2020, vehiculo.Año);
        Assert.Equal(25000.0, vehiculo.Precio);
        Assert.Equal(50000, vehiculo.Kilometros);
    }

    [Theory]
    [InlineData(500, "Nuevo")]
    [InlineData(1000, "Nuevo")]
    [InlineData(1001, "Usado")]
    [InlineData(50000, "Usado")]
    public void Estado_DeberiaRetornarEstadoCorreecto(int kilometros, string estadoEsperado)
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, kilometros);
        
        // Act
        var estado = vehiculo.Estado;
        
        // Assert
        Assert.Equal(estadoEsperado, estado);
    }

    [Fact]
    public void Antigüedad_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 10000);
        var antigüedadEsperada = DateTime.Now.Year - 2020;
        
        // Act
        var antigüedad = vehiculo.Antigüedad;
        
        // Assert
        Assert.Equal(antigüedadEsperada, antigüedad);
    }

    [Fact]
    public void DepreciacionKilometraje_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 30000);
        
        // Act
        var depreciacion = vehiculo.DepreciacionKilometraje;
        
        // Assert
        Assert.Equal(3000.0, depreciacion); // 30000 * 0.10
    }

    [Fact]
    public void ValorReal_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 20000);
        
        // Act
        var valorReal = vehiculo.ValorReal;
        
        // Assert
        Assert.Equal(23000.0, valorReal); // 25000 - (20000 * 0.10)
    }

    [Fact]
    public void NombreCompleto_DeberiaFormatearCorrectamente()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "BMW", "Serie 3", 2023, 45000.0, 5000);
        
        // Act
        var nombreCompleto = vehiculo.NombreCompleto;
        
        // Assert
        Assert.Equal("BMW Serie 3 (2023)", nombreCompleto);
    }

    [Fact]
    public void AñadeKilometros_DeberiaIncrementarCorrectamente()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 10000);
        
        // Act
        vehiculo.AñadeKilometros(5000);
        
        // Assert
        Assert.Equal(15000, vehiculo.Kilometros);
    }

    [Fact]
    public void AplicaDescuento_DeberiaReducirPrecio()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 20000.0, 10000);
        
        // Act
        vehiculo.AplicaDescuento(10); // 10% de descuento
        
        // Assert
        Assert.Equal(18000.0, vehiculo.Precio);
    }

    [Fact]
    public void AplicaDescuento_ConMultiplesDescuentos_DeberiaAcumular()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 20000.0, 10000);
        
        // Act
        vehiculo.AplicaDescuento(10); // Primer descuento del 10%
        vehiculo.AplicaDescuento(5);  // Segundo descuento del 5% sobre el precio ya descontado
        
        // Assert
        Assert.Equal(17100.0, vehiculo.Precio); // 20000 * 0.9 * 0.95
    }

    [Fact]
    public void ActualizaPrecio_DeberiaEstablecerNuevoPrecio()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 20000.0, 10000);
        
        // Act
        vehiculo.ActualizaPrecio(22000.0);
        
        // Assert
        Assert.Equal(22000.0, vehiculo.Precio);
    }

    [Fact]
    public void ACadena_DeberiaContenerInformacionCompleta()
    {
        // Arrange
        var vehiculo = new Vehiculo("5678DEF", "BMW", "X5", 2022, 50000.0, 15000);
        
        // Act
        var cadena = vehiculo.ACadena();
        
        // Assert
        Assert.Contains("5678DEF", cadena);
        Assert.Contains("BMW X5 (2022)", cadena);
        Assert.Contains("50000", cadena);
        Assert.Contains("15000", cadena);
        Assert.Contains(vehiculo.Estado, cadena);
        Assert.Contains(vehiculo.ValorReal.ToString("F2"), cadena);
        Assert.Contains(vehiculo.Antigüedad.ToString(), cadena);
    }

    [Fact]
    public void PropiedadesAutoimplementadas_SettersPrivados_NoDeberianSerAccesibles()
    {
        // Arrange
        var vehiculo = new Vehiculo("1234ABC", "Toyota", "Corolla", 2020, 25000.0, 10000);
        
        // Assert - Verificamos que las propiedades no tienen setters públicos
        // Esto se verifica en tiempo de compilación, pero podemos verificar que los valores
        // solo cambian a través de los métodos específicos
        var matriculaOriginal = vehiculo.Matricula;
        var marcaOriginal = vehiculo.Marca;
        var modeloOriginal = vehiculo.Modelo;
        var añoOriginal = vehiculo.Año;
        
        // Después de realizar operaciones, estos valores no deberían cambiar
        vehiculo.AñadeKilometros(1000);
        vehiculo.AplicaDescuento(5);
        
        Assert.Equal(matriculaOriginal, vehiculo.Matricula);
        Assert.Equal(marcaOriginal, vehiculo.Marca);
        Assert.Equal(modeloOriginal, vehiculo.Modelo);
        Assert.Equal(añoOriginal, vehiculo.Año);
    }
}
