using System;
using System.Text.RegularExpressions;

namespace ejercicio2.tests;

public class ProductoTests
{
    [Fact]
    public void Constructor_DeberiaCrearCodigoUnico()
    {
        // Arrange & Act
        var producto1 = new Producto("Laptop", 1000, 10);
        var producto2 = new Producto("Mouse", 50, 20);

        // Assert
        Assert.NotEqual(producto1.Codigo, producto2.Codigo);
        Regex regex = new Regex(@"^PR\d[A-Z]{3}$");
        Assert.Matches(regex, producto1.Codigo);
        Assert.Matches(regex, producto2.Codigo);
        Assert.Single(Producto.CodigosGenerados.ToList().FindAll(codigo => codigo == producto1.Codigo));
        Assert.Single(Producto.CodigosGenerados.ToList().FindAll(codigo => codigo == producto2.Codigo));
    }

    [Fact]
    public void Constructor_DeberiaValidarPrecioYStock()
    {
        // Arrange & Act
        var producto1 = new Producto("Test", -100, -5);

        // Assert
        Assert.Equal(20.0, producto1.Precio); // Precio por defecto
        Assert.Equal(1, producto1.Stock); // Stock por defecto
    }

    [Fact]
    public void Propiedades_ReadOnly_DeberianDevolverValoresCorrectos()
    {
        // Arrange & Act
        var producto = new Producto("Laptop Gaming", 1500, 5);

        // Assert
        Assert.Equal("Laptop Gaming", producto.Nombre);
        Assert.NotNull(producto.Codigo);
    }

    [Fact]
    public void Precio_Set_DeberiaValidarValor()
    {
        // Arrange
        var producto = new Producto("Test", 100, 10);

        // Act & Assert
        producto.Precio = 200;
        Assert.Equal(200, producto.Precio);

        producto.Precio = -50;
        Assert.Equal(20.0, producto.Precio); // Valor por defecto

        producto.Precio = 0;
        Assert.Equal(20.0, producto.Precio); // Valor por defecto
    }

    [Fact]
    public void Stock_Set_DeberiaValidarValor()
    {
        // Arrange
        var producto = new Producto("Test", 100, 10);

        // Act & Assert
        producto.Stock = 50;
        Assert.Equal(50, producto.Stock);

        producto.Stock = -10;
        Assert.Equal(1, producto.Stock); // Valor por defecto
    }

    [Fact]
    public void ValorTotal_DeberiaCalcularCorrectamente()
    {
        // Arrange
        var producto = new Producto("Test", 25.50, 10);

        // Act
        var valorTotal = producto.ValorTotal;

        // Assert
        Assert.Equal(255.0, valorTotal);
    }

    [Theory]
    [InlineData(0, "Sin stock")]
    [InlineData(5, "Stock bajo")]
    [InlineData(15, "En stock")]
    public void Estado_DeberiaRetornarEstadoCorreecto(int stock, string estadoEsperado)
    {
        // Arrange
        var producto = new Producto("Test", 100, stock);

        // Act
        var estado = producto.Estado;

        // Assert
        Assert.Equal(estadoEsperado, estado);
    }

    [Fact]
    public void Vende_ConStockSuficiente_DeberiaRetornarTrueYReducirStock()
    {
        // Arrange
        var producto = new Producto("Test", 100, 20);

        // Act
        bool resultado = producto.Vende(5);

        // Assert
        Assert.True(resultado);
        Assert.Equal(15, producto.Stock);
    }

    [Fact]
    public void Vende_ConStockInsuficiente_DeberiaRetornarFalseySinCambios()
    {
        // Arrange
        var producto = new Producto("Test", 100, 5);

        // Act
        bool resultado = producto.Vende(10);

        // Assert
        Assert.False(resultado);
        Assert.Equal(5, producto.Stock);
    }

    [Fact]
    public void Repone_DeberiaAumentarStock()
    {
        // Arrange
        var producto = new Producto("Test", 100, 10);

        // Act
        producto.Repone(5);

        // Assert
        Assert.Equal(15, producto.Stock);
    }

    [Fact]
    public void AplicaDescuento_DeberiaReducirPrecio()
    {
        // Arrange
        var producto = new Producto("Test", 100, 10);

        // Act
        producto.AplicaDescuento(10); // 10% de descuento

        // Assert
        Assert.Equal(90.0, producto.Precio);
    }

    [Fact]
    public void AplicaDescuento_NoDeberiaDejarPrecioEnCeroONegativo()
    {
        // Arrange
        var producto = new Producto("Test", 10, 5);

        // Act
        producto.AplicaDescuento(150); // 150% de descuento

        // Assert
        Assert.Equal(20.0, producto.Precio); // Precio mínimo
    }

    [Fact]
    public void ACadena_DeberiaContenerInformacionCompleta()
    {
        // Arrange
        var producto = new Producto("Laptop Gaming", 1200, 5);

        // Act
        var cadena = producto.ACadena();

        // Assert
        Assert.Contains(producto.Codigo, cadena);
        Assert.Contains("Laptop Gaming", cadena);
        Assert.Contains("1200", cadena);
        Assert.Contains("5", cadena);
        Assert.Contains(producto.Estado, cadena);
        Assert.Contains(producto.ValorTotal.ToString("F2"), cadena);
    }
}
